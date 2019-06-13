module Chapter4

module Houses =

    type House = { Address : string; Price : decimal }
    type PriceBand = Cheap | Medium | Expensive
    
    let getHouses count =
        let random = System.Random(Seed = 1)
        Array.init count (fun i -> 
            { Address = sprintf "%i Stochastic Street" (i+1)
              Price = random.Next(50_000, 500_000) |> decimal })

    let random = System.Random(Seed = 1)
    
    let trySchoolDistance (house : House) =
        let dist = random.Next(10) |> double
        if dist < 8. then
            Some dist
        else
            None

    let priceBand (price : decimal) =
        if price < 100_000m then 
            Cheap
        else if price < 200_000m then 
            Medium
        else 
            Expensive

module Exercise1 =

    open Houses

    let housePrices =
        getHouses 20
        |> Array.map (fun h ->
            sprintf "Address: %s - Price: %f" h.Address h.Price)

module Exercise2 =
    
    open Houses

    let averageHousePrice =
        getHouses 20
        |> Array.averageBy (fun h ->
            h.Price)

module Exercise3 =
    
    open Houses

    let housesCostingMoreThan250k =
        getHouses 20
        |> Array.filter (fun h ->
            h.Price > 250_000m)