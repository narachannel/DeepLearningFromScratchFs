#load ".paket/load/main.group.fsx"

open System
open System.IO
open System.IO.Compression
open FSharp.Core
open MathNet.Numerics
open MathNet.Numerics.LinearAlgebra
open XPlot.Plotly
open System.Net
    
let downloadFile (url : string)  (file : string) =
    use client = new WebClient()
    client.DownloadFile(url, file)

let url = "http://yann.lecun.com/exdb/mnist/"
let files = dict[("train_img", "train-images-idx3-ubyte.gz");
                    ("train_label", "train-labels-idx1-ubyte.gz");
                    ("test_img", "t10k-images-idx3-ubyte.gz");
                    ("test_label","t10k-labels-idx1-ubyte.gz")]

let loadFromGzip (file : string) (offset : int) =
    use reader = new GZipStream(File.OpenRead(file), CompressionMode.Decompress)
    let mutable buffer = Array.empty
    reader.Read(buffer, 1, offset) |> ignore
    buffer

let loadLabel (file : string) =
    loadFromGzip file 8

let loadImage (file : string) =
    loadFromGzip file 16

