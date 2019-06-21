module Chapter11

module Exercise1 =
    
    type Outcome<'TSuccess, 'TFailure> =
           | Success of 'TSuccess
           | Failure of 'TFailure

    let adapt func input =
        match input with
        | Success x -> func x
        | Failure f -> Failure f

    let passThrough func input =
        match input with
        | Success x -> func x |> Success
        | Failure f -> Failure f

    let passThroughRejects func input =
        match input with
        | Success x -> Success x
        | Failure f -> func f |> Failure

module Exercise2 =

       open System

       type Message = 
           { FileName : string
             Content : float[] }

       type Reading =
           { TimeStamp : DateTimeOffset
             Data : float[] }

       let example =
           [|
               { FileName = "2019-02-23T02:00:00-05:00"
                 Content = [|1.0; 2.0; 3.0; 4.0|] }
               { FileName = "2019-02-23T02:00:10-05:00"
                 Content = [|5.0; 6.0; 7.0; 8.0|] }
               { FileName = "error"
                 Content = [||] }
               { FileName = "2019-02-23T02:00:20-05:00"
                 Content = [|1.0; 2.0; 3.0; Double.NaN|] }
           |]

       let log s = printfn "Logging: %s" s

       type MessageError =
           | InvalidFileName of fileName:string
           | DataContainsNaN of fileName:string * index:int

       let getReading message =
           match DateTimeOffset.TryParse(message.FileName) with
           | true, dt -> 
               let reading = { TimeStamp = dt; Data = message.Content }
               (message.FileName, reading) |> Ok
           | false, _ -> 
               message.FileName |> InvalidFileName |> Error

       let validateData(fileName, reading) =
           let nanIndex = 
               reading.Data
               |> Array.tryFindIndex (Double.IsNaN)
           match nanIndex with
           | Some i -> 
               (fileName, i) |> DataContainsNaN |> Error
           | None -> 
               Ok reading

       let logError e =
           match e with
           | InvalidFileName fn -> sprintf "Invalid file name: '%s'" fn
           | DataContainsNaN (fn, i) -> sprintf "NaN at %i in %s" i fn