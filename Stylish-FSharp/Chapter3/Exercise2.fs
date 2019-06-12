module Exercise2

    type BillingDetails = {
        name : string
        billing :  string
        delivery : string option }

    let countOfBillings (billings: BillingDetails seq) =
        billings
        |> Seq.map (fun x -> x.billing)
        |> Seq.map Option.ofObj
        |> Seq.sumBy Option.count