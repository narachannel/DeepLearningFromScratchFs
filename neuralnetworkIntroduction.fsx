#load ".paket/load/main.group.fsx"

open System
open FSharp.Core
open MathNet.Numerics
open XPlot.Plotly;

let stepFunction (list : float list) =
    List.map (fun x -> if x > 0. then 1.0 else 0.0 ) list

let x = [-5.0 .. 0.1 .. 5.0]
//stepFunction x

let sigmoid (list : float list) = 
    List.map (fun x -> 1. / (1. + exp(- x))) list

let rectifiedLinearUnit (list : float list) =
    List.map (fun x -> Math.Max(0., x)) list
[Scatter(x = x, y = stepFunction x); 
Scatter(x = x, y = sigmoid x);
Scatter(x = x, y = rectifiedLinearUnit x)] |> Chart.Plot |> Chart.WithWidth 700 |> Chart.WithHeight 500 |> Chart.Show
