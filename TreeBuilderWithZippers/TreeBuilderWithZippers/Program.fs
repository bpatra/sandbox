module Program

open MutableTree

[<EntryPoint>]
let main args =
    let initialTree = ref Tree.Empty
    let branch1 = ["a";"b";"c"]
    let branch2 = ["a";"b";"d"]

    do mergeInto initialTree branch1
    //-> my tree is ok
    do mergeInto initialTree branch2
    //->not ok, expected a
    //                   |
    //                   b
    //                  / \
    //                 d   c 
    // Return 0. This indicates success.
    0