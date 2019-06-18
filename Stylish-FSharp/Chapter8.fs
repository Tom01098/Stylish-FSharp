module Chapter8

module Exercise1 =

    type Greyscale(r : byte, g : byte, b : byte) =
    
        member __.Level =
            (int r + int g + int b) / 3 |> byte

module Exercise2 =
    
    open System.Drawing

    type Greyscale(r : byte, g : byte, b : byte) =

        new(colour : Color) =
            Greyscale(colour.R, colour.B, colour.G)
    
        member __.Level =
            (int r + int g + int b) / 3 |> byte

module Exercise3 =
    
    open System.Drawing

    type Greyscale(r : byte, g : byte, b : byte) =

        new(colour : Color) =
            Greyscale(colour.R, colour.B, colour.G)
    
        member __.Level =
            (int r + int g + int b) / 3 |> byte

        override this.ToString() =
            sprintf "Grayscale(%i)" this.Level