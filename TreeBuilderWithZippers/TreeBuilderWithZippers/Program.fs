module Program

open MutableTree
open TreeZipper
open System

//[<EntryPoint>]
//let main args =
//    let initialTree = ref Tree.Empty
//    let branch1 = ["a";"b";"c"]
//    let branch2 = ["a";"b";"d"]
//
//    do mergeInto initialTree branch1
//    -> my tree is ok
//    do mergeInto initialTree branch2
//    ->not ok, expected a
//                       |
//                       b
//                      / \
//                     d   c 
//     Return 0. This indicates success.
//    0

[<EntryPoint>]
let main args =
     let branch1 = ["a";"b";"c"]
     let tree1 = appendToTree Tree.Empty branch1
     let branch2 = ["a";"b";"d"]
     let tree2 =  appendToTree tree1 branch2
     let branch3 = ["a";"f"]
     let final = appendToTree tree2 branch3               

     Console.ReadLine() |> ignore
     0