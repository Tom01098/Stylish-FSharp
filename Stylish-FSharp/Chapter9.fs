module Chapter9

module Exercise1 =
    
    let applyAndPrint f a b =
        let r = f a b
        printfn "%i" r

    let multiply a b = a * b

module Exercise2 =
    
    let rangeCounter min max =
        let mutable current = min
        fun () ->
            let before = current
            if current = max then
                current <- min
            else
                current <- current + 1
            before

module Exercise3 =

    let featureScale a b xMin xMax x =
        a + ((x - xMin) * (b - a)) / (xMax - xMin)

    let scale (data : seq<float>) =
        let minX = data |> Seq.min
        let maxX = data |> Seq.max
        let zeroOneScale = featureScale 0. 1. minX maxX
        data
        |> Seq.map zeroOneScale

module Exercise4 = 

    let applyAll p = p |> List.reduce (>>)