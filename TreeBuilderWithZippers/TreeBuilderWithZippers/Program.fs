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
    let basicTree = TreeNode("a",[ TreeNode("b", [TreeNode("d", []); TreeNode("e", []); TreeNode("f",[])]) ; TreeNode("c", [TreeNode("g", [TreeNode("i",[])]);TreeNode("h",[])])])
    let myZipper = zipper basicTree
    let zipp_on_g= myZipper |> go_down |> go_right |> go_down

    Console.ReadLine() |> ignore
    0