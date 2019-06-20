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