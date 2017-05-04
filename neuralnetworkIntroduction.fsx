#load ".paket/load/main.group.fsx"

open System
open FSharp.Core
open MathNet.Numerics
open MathNet.Numerics.LinearAlgebra
open XPlot.Plotly

let stepFunction v =
    Vector.map (fun x -> if x > 0. then 1.0 else 0.0 ) v

let x = vector [-5.0 .. 0.1 .. 5.0]

let sigmoid (v : Vector<float>) = 
    Vector.map (fun x -> 1. / (1. + exp(- x))) v

let rectifiedLinearUnit v =
    Vector.map (fun x -> Math.Max(0., x)) v

[Scatter(x = x, y = stepFunction x); Scatter(x = x, y = sigmoid x);Scatter(x = x, y = rectifiedLinearUnit x)] 
|> Chart.Plot |> Chart.WithWidth 700 |> Chart.WithHeight 500 //|> Chart.Show

let w1 = matrix [[0.1; 0.3; 0.5]; [0.2; 0.4; 0.6]]
let w2 = matrix [[0.1; 0.4]; [0.2; 0.5]; [0.3; 0.6]]
let w3 = matrix [[0.1; 0.3]; [0.2; 0.4]]

let b1 = vector [0.1; 0.2; 0.3]
let b2 = vector [0.1; 0.2]
let b3 = vector [0.1; 0.2]

let forward x = 
    let a1 = x * w1 + b1
    let z1 = sigmoid a1
    let a2 = z1 * w2 + b2
    let z2 = sigmoid a2
    z2 * w3 + b3

forward (vector [1.0; 0.5])

let softmax (v : Vector<float>) =
    let m = Vector.max v
    let factor = Vector.toArray v |> Array.sumBy(fun x -> exp(x - m))
    1. / factor * (Vector.map (fun x -> exp(x - m)) v)