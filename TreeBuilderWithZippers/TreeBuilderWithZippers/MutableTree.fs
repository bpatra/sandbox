module MutableTree

open System

type Tree =
    |Node of string*list<Tree ref>
    |Empty

let rec branchToTree (inputList:list<string>) =
    match inputList with
        | [] -> Tree.Empty
        | head::tail ->  Tree.Node (head, [ref (branchToTree tail)])

//branch cannot be empty list
let rec mergeInto (tree:Tree ref) (branch:list<string>) =
    match !tree,branch with
        | Node (value,_), head::tail when value <> head -> failwith "Oops invariant loop broken"
        | Node (value,_), [_] -> ignore() //the branch is singleton and by loop invariant its head is the current Tree node -> nothing to do.
        | Node (value,children), _ -> 
                                let nextBranchValue = branch.Tail.Head //valid because of previous match

                                //broken attempt to retrieve a ref to the proper child
                                let targetChild = children 
                                                |> List.tryFind (fun(child) -> match !child with
                                                                                        |Empty -> false
                                                                                        |Node (value,_) -> value = nextBranchValue)
                                match targetChild with
                                    |Some x -> mergeInto x branch.Tail //a valid child match then go deeper. NB: branch.Tail cannot be empty here
                                    |None -> tree := Node(value, (ref (Node (nextBranchValue,[]))) :: children)//attach the next branch value to the children
        | Empty,_ -> tree := branchToTree branch
