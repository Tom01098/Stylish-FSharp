module Exercise1

    type Delivery =
    | AsBilling
    | Physical of string
    | Download
    | ClickAndCollect of int

    type BillingDetails = {
        name : string
        billing :  string
        delivery : Delivery }

    let tryDeliveryLabel (billingDetails : BillingDetails) =
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

    let deliveryLabels (billingDetails : BillingDetails seq) =
        billingDetails
        |> Seq.choose tryDeliveryLabel

    let collectionsFor store billingDetails = 
        billingDetails
        |> Seq.choose (fun billing ->
            match billing.delivery with
            | ClickAndCollect id when id = store -> Some billing
            | _ -> None)