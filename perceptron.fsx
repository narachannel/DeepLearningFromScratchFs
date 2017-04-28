open System

let andGate x1 x2 = 
    let w1 = 0.5
    let w2 = 0.5
    let theta = 0.7
    let tmp = x1 * w1 + x2 * w2
    if tmp <= theta then  0 else 1

//andGate 0. 0.
//andGate 1. 0.
//andGate 0. 1.
//andGate 1. 1.

let nandGate x1 x2 =
    let w1 = -0.5
    let w2 = -0.5
    let theta = -0.7
    let tmp = x1 * w1 + x2 * w2
    if tmp <= theta then  0 else 1

let orGate x1 x2 = 
    let w1 = 0.5
    let w2 = 0.5
    let theta = 0.2
    let tmp = x1 * w1 + x2 * w2
    if tmp <= theta then  0 else 1

let xorGate x1 x2 =
    let s1 = nandGate x1 x2
    let s2 = orGate x1 x2
    andGate (float s1) (float s2)

xorGate 0. 0.
xorGate 1. 0.
xorGate 0. 1.
xorGate 1. 1.
