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