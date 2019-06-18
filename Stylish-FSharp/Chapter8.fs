module Chapter8

module Exercise1 =

    type Greyscale(r : byte, g : byte, b : byte) =
    
        member __.Level =
            (int r + int g + int b) / 3 |> byte

module Exercise2 =
    
    open System.Drawing

    type Greyscale(r : byte, g : byte, b : byte) =

        new(colour : Color) =
            Greyscale(colour.R, colour.G, colour.B)
    
        member __.Level =
            (int r + int g + int b) / 3 |> byte

module Exercise3 =
    
    open System.Drawing

    type Greyscale(r : byte, g : byte, b : byte) =

        new(colour : Color) =
            Greyscale(colour.R, colour.G, colour.B)
    
        member __.Level =
            (int r + int g + int b) / 3 |> byte

        override this.ToString() =
            sprintf "Grayscale(%i)" this.Level

module Exercise4 =
        
    open System
    open System.Drawing

    type Greyscale(r : byte, g : byte, b : byte) =

        let level = (int r + int g + int b) / 3 |> byte
        
        let eq (that : Greyscale) =
            level = that.Level

        new(colour : Color) =
            Greyscale(colour.R, colour.G, colour.B)
    
        member __.Level = level

        override this.ToString() =
            sprintf "Grayscale(%i)" this.Level

        override __.GetHashCode() =
            hash level

        override __.Equals(obj) =
            match obj with
            | :? Greyscale as that -> eq that
            | _ -> false

        interface IEquatable<Greyscale> with
            member __.Equals(that : Greyscale) = 
                eq that