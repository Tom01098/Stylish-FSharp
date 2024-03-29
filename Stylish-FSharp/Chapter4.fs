﻿module Chapter4

module Houses =

    type House = { Address : string; Price : decimal }
    type PriceBand = Cheap | Medium | Expensive
    
    let random = System.Random(Seed = 1)

    let getHouses count =
        Array.init count (fun i -> 
            { Address = sprintf "%i Stochastic Street" (i+1)
              Price = random.Next(50_000, 500_000) |> decimal })
    
    let trySchoolDistance (house : House) =
        let dist = random.Next(10) |> double
        if dist < 8. then
            Some dist
        else
            None

    let priceBand price =
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
        |> Array.averageBy (fun h -> h.Price)

module Exercise3 =
    
    open Houses

    let housesCostingMoreThan250k =
        getHouses 20
        |> Array.filter (fun h -> h.Price > 250_000m)

module Exercise4 =
    
    open Houses

    let housesNearSchools =
        getHouses 20
        |> Array.choose (fun h ->
            match trySchoolDistance h with
            | Some dist -> Some (h, dist)
            | None -> None)

module Exercise5 =
    
    open Houses

    let printHouseCostingMoreThan100k =
        getHouses 20
        |> Array.filter (fun h -> h.Price > 100_000m)
        |> Array.iter (fun h ->
            printfn "Address: %s - Price: %f" h.Address h.Price)

module Exercise6 =
    
    open Houses

    let printHouseCostingMoreThan100kDescending =
        getHouses 20
        |> Array.filter (fun h -> h.Price > 100_000m)
        |> Array.sortByDescending (fun h -> h.Price)
        |> Array.iter (fun h ->
            printfn "Address: %s - Price: %f" h.Address h.Price)

module Exercise7 =
    
    open Houses

    let averageHousePriceOver200k =
        getHouses 20
        |> Array.filter (fun h -> h.Price > 200_000m)
        |> Array.averageBy (fun h -> h.Price)

module Exercise8 =

    open Houses

    let firstHouseUnder100kNearSchool =
        getHouses 20
        |> Array.filter (fun h -> h.Price < 100_000m)
        |> Array.pick (fun h ->
            match trySchoolDistance h with
            | Some dist -> Some (h, dist)
            | None -> None)

module Exercise9 =
    
    open Houses

    let groupHousesByPriceBand =
        getHouses 20
        |> Array.groupBy (fun h -> priceBand h.Price)
        |> Array.map (fun (band, hs) -> 
            band, hs |> Array.sortBy (fun h -> h.Price))

module Array =

    let inline tryAverageBy projection a =
        if Array.length a = 0 then None
        else a |> Array.averageBy projection |> Some

module Exercise10 =
    
    open Houses

    let averagePriceOver200k =
        getHouses 20
        |> Array.filter (fun h -> h.Price > 200_000m)
        |> Array.tryAverageBy (fun h -> h.Price)
        |> Option.defaultValue 0m

module Exercise11 =
    
    open Houses

    let firstHouseLessThan100kNearSchool =
        getHouses 20
        |> Array.filter (fun h -> h.Price < 100_000m)
        |> Array.tryPick (fun h ->
            match trySchoolDistance h with
            | Some dist -> Some (h, dist)
            | None -> None)