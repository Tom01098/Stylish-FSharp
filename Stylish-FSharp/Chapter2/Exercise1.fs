module Exercise1

open System

module MilesYards = 

    type MilesYards = 
        private MilesYards of wholeMiles : int * yards : int

    let fromMilesPointYards (milesPointYards : float) : MilesYards =
        let wholeMiles = milesPointYards |> floor |> int
        let fraction = milesPointYards - float(wholeMiles)
        if fraction > 0.1759 then
            raise <| ArgumentOutOfRangeException("milesPointYards", "Fractional part must be <= 0.1759")
        elif fraction < 0. then
            raise <| ArgumentOutOfRangeException("milesPointYards", "Fractional part must be >= 0")
        let yards = fraction * 10_000. |> round |> int
        MilesYards(wholeMiles, yards)

    let toDecimalMiles (MilesYards(wholeMiles, yards)) : float =
        (float wholeMiles) + ((float yards) / 1760.)