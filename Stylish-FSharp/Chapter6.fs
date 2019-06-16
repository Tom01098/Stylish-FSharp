module Chapter6

module Exercise1 =

    open System
    
    type MeterValue =
        | Standard of int
        | Economy7 of Day:int * Night:int

    type MeterReading =
        { ReadingDate : DateTime
          MeterValue : MeterValue}

    let formatReading { ReadingDate = date; MeterValue = value } =
        let dateStr = date.ToShortDateString()
        match value with
        | Standard reading ->
            sprintf "Your reading on: %s was %07i" dateStr reading
        | Economy7(Day=day; Night=night) ->
            sprintf "Your readings on: %s: Day: %07i Night: %07i" dateStr day night

module Exercise2 =
    
    type FruitBatch = { Name:string; Count:int }

    let fruits =
        [ 
            { Name = "Apples"; Count = 3 }
            { Name = "Oranges"; Count = 4 }
            { Name = "Bananas"; Count = 2 } 
        ]
        
    // There are 3 Apples
    // There are 4 Oranges
    // There are 2 Bananas
    for { Name = name; Count = count } in fruits do
        printfn "There are %i %s" count name

    // There are 3 Apples
    // There are 4 Oranges
    // There are 2 Bananas
    fruits
    |> List.iter (fun { Name = name; Count = count } ->
        printfn "There are %i %s" count name)