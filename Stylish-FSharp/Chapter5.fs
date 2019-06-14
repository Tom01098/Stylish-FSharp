module Chapter5

module Exercise1 =

    let clip max s = s |> Seq.map (min max)

module Exercise2 =
    
    open System

    let extremesMut s =
        let mutable min = Double.MaxValue
        let mutable max = Double.MinValue
        for item in s do
            if item < min then
                min <- item
            if item > max then
                max <- item
        min, max

    let extremes s =
        s |> Seq.min,
        s |> Seq.max
