module TreeZipper

open System

type Tree =
        |TreeNode of string* Tree list
        |Empty
        member this.GetLabel =
            match this with
            | Empty -> failwith "cannot get the label of an empty tree"
            | TreeNode(lbl,_) -> lbl

let rec branchToTree (inputList:list<string>) =
    match inputList with
        | [] -> Tree.Empty
        | head::tail ->  TreeNode (head, [branchToTree tail])
            
type Path =
        |Top of string
        |PathNode of string*Tree list * Path * Tree list
         member this.GetLabel =
            match this with
            | Top(lbl) -> lbl
            | PathNode(lbl,_,_,_) ->lbl

type Location =
        Loc of Tree*Path

let go_left (Loc(t,p)) =
        match p with
        | Top(-) -> failwith "cannot go left on top"
        | PathNode(_,[],_,_) -> failwith "no elder simbling"
        | PathNode(_,l::left, up, right) -> Loc(l,PathNode(l.GetLabel,left,up ,t::right))

let go_right (Loc(t,p)) =
        match p with
        | Top(_) -> failwith "cannot go right on top"
        | PathNode(_,_,_,[]) -> failwith "no younger simbling"
        | PathNode (_,left, up, r::right) -> Loc(r, PathNode(r.GetLabel,r::left,up, right))

let go_up (Loc(t, p)) =
        match p with
        | Top(_) -> failwith "cannot go up, already on top"
        | PathNode(_,left,up, right) -> Loc(TreeNode(up.GetLabel,(List.rev left) @ t::right), up)

let go_down (Loc(t,p)) =
        match t with
        | Empty -> failwith "cannot go down an empty tree"
        | TreeNode(_,[])-> failwith "no children cannot go further"
        | TreeNode(label,first::childs) -> Loc(first,PathNode(first.GetLabel,[],p, childs))

let insert_left l (Loc(t,p)) =
        match p with 
        | Top(_) -> failwith "cannot insert left on top"
        | PathNode(lbl, left, up, right) -> Loc(t, PathNode(lbl,l::left,up, right))

let insert_right r (Loc(t,p)) =
        match p with 
        | Top(_) -> failwith "cannot insert right on top"
        | PathNode(lbl, left, up, right) -> Loc(t, PathNode(lbl,left,up, r::right))

let insert_down t1 (Loc(t,p)) =
        match t with
        | Empty -> Loc(t1, Top(t1.GetLabel))
        | TreeNode(label, children) -> Loc(t1, PathNode(t1.GetLabel,[],p, children))

let rec root (Loc (t, p) as l) = 
        match p with 
        | Top(_) -> t
        | _ -> root (go_up l) 

let getZipper t = 
    match t with
        | Empty -> Loc(Empty, Top(""))
        | TreeNode(value,_ )-> Loc(t, Top(value))

let rec appendToTreeZipper (Loc (t,p) as l) (branch:list<string>) =
    let rightSiblings = match p with
                        | Top(_) -> []
                        | PathNode(_,_,_,rights) -> rights
    let currentValue = match t with
                        | Empty -> None
                        | TreeNode(value,_) -> Some(value)

    match currentValue,rightSiblings,branch with
        | None,_,_ -> insert_down <| branchToTree branch<| l 
        | Some(x), _, head::tail when x = head -> appendToTreeZipper <| go_down l <| tail 
        | _, [] ,_  ->  insert_right <| TreeNode(branch.Head,[Tree.Empty]) <| l
        | _, _,_ -> appendToTreeZipper <| go_right l <| branch

let appendToTree t (branch:list<string>) =
    appendToTreeZipper <| getZipper t <| branch
        |> root         