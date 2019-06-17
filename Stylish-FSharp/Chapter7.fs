﻿module Chapter7

module Exercise1 =

    open System
    
    type PositionRef = {
        X : float32
        Y : float32
        Z : float32
        Time : DateTime }

    [<Struct>]
    type PositionStruct = {
        X : float32
        Y : float32
        Z : float32
        Time : DateTime }

    let refs = Array.init 1_000_000 (fun i -> 
        { PositionRef.X = float32 i
          Y = float32 i
          Z = float32 i
          Time = DateTime.Now })

    let structs = Array.init 1_000_000 (fun i -> 
        { PositionStruct.X = float32 i
          Y = float32 i
          Z = float32 i
          Time = DateTime.Now })