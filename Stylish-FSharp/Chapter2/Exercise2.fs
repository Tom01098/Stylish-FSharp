module Exercise2

    open System

    module MilesChains =

        type MilesChains =
            private MilesChains of wholeMiles : int * chains : int

        let fromMilesChains (miles, chains) =
            if miles < 0 then
                raise <| ArgumentOutOfRangeException("miles", "Must be positive.")
            elif chains < 0 || chains > 80 then
                raise <| ArgumentOutOfRangeException("chains", "Must be between 0 and 80.")

            MilesChains (miles, chains)

        let toDecimalMiles (MilesChains(miles, chains)) =
            (float miles) + ((float chains) / 80.)