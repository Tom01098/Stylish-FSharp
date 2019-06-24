module Chapter12

module Exercise1 =

    type Transaction = { Id : int }

    let addTransactions
        (oldTransactions : Transaction[])
        (newTransactions : Transaction[]) =
        Array.append oldTransactions newTransactions