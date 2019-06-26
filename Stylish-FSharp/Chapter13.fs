module Chapter13

module private Files =
    
    open System.IO
    open System.Text.RegularExpressions

    let getAllIn dir =
        Directory.EnumerateFiles
                      (dir, "*.*", SearchOption.AllDirectories)

    let nameMatches (regex:Regex) (file:string) =
        regex.IsMatch(Path.GetFileName(file))

module private FileAttributes =
    
    open System.IO

    let hasFlag flag file =
        FileInfo(file)
            .Attributes
            .HasFlag(flag)

module Exercise1 = 

    open System.IO
    open System.Text.RegularExpressions

    let find pattern dir =
        let re = Regex(pattern)
        Files.getAllIn dir
        |> Seq.filter (Files.nameMatches re)
        |> Seq.filter (FileAttributes.hasFlag FileAttributes.ReadOnly)