module TreeZipper

open System

type Tree =
        |TreeNode of string* Tree list
        
        member this.GetLabel =
            match this with
             | TreeNode(lbl,_) -> lbl
            
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
            |Top(-) -> failwith "cannot go left on top"
            |PathNode(_,[],_,_) -> failwith "no elder simbling"
            |PathNode(_,l::left, up, right) -> Loc(l,PathNode(l.GetLabel,left,up ,t::right))

let go_right (Loc(t,p)) =
        match p with
            |Top(_) -> failwith "cannot go right on top"
            |PathNode(_,_,_,[]) -> failwith "no younger simbling"
            |PathNode (_,left, up, r::right) -> Loc(r, PathNode(r.GetLabel,r::left,up, right))

let go_up (Loc(t, p)) =
        match p with
            |Top(_) -> failwith "cannot go up, already on top"
            |PathNode(_,left,up, right) -> Loc(TreeNode(up.GetLabel,(List.rev left) @ t::right), up)

let go_down (Loc(t,p)) =
        match t with
        | TreeNode(_,[])-> failwith "no children cannot go further"
        | TreeNode(label,first::childs) -> Loc(first,PathNode(first.GetLabel,[],p, childs))


