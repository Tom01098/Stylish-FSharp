module Chapter3

module Exercise1 =

    type Delivery =
        | AsBilling
        | Physical of string
        | Download
        | ClickAndCollect of int

    type BillingDetails = {
        name : string
        billing : string
        delivery : Delivery }

    let tryDeliveryLabel billingDetails =
        match billingDetails.delivery with
        | AsBilling -> 
            billingDetails.billing |> Some
        | Physical address -> 
            address |> Some
        | Download -> None
        | ClickAndCollect store ->
            store |> string |> Some
        |> Option.map (fun address -> 
            sprintf "%s\n%s" billingDetails.name address)

    let deliveryLabels billingDetails =
        billingDetails
        |> Seq.choose tryDeliveryLabel

    let collectionsFor store billingDetails = 
        billingDetails
        |> Seq.choose (fun billing ->
            match billing.delivery with
            | ClickAndCollect id when id = store -> Some billing
            | _ -> None)

module Exercise2 =

    type BillingDetails = {
        name : string
        billing : string
        delivery : string option }

    let countOfBillings billings =
        billings
        |> Seq.map (fun x -> x.billing)
        |> Seq.map Option.ofObj
        |> Seq.sumBy Option.count