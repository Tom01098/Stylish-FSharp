module Chapter12

module Exercise1 =

    type Transaction = { Id : int }

    let addTransactions
        (oldTransactions : Transaction[])
        (newTransactions : Transaction[]) =
        Array.append oldTransactions newTransactions

module Exercise3 =

    open System
    open System.Text

    let buildCsv (data : float[,]) =
        let strings = data |> Array2D.map (sprintf "%f")
        let sb = StringBuilder()
        for row = 0 to Array2D.length1 strings - 1 do
            sb.AppendLine(String.Join(',', strings.[row, *])) |> ignore
        sb.ToString()