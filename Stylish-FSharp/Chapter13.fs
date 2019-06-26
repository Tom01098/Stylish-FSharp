module Chapter13

module private Files =
    
    open System.IO
    open System.Text.RegularExpressions

    let getAllFilesIn dir =
        Directory.EnumerateFiles
                      (dir, "*.*", SearchOption.AllDirectories)

    let nameMatches (regex:Regex) (file:string) =
        regex.IsMatch(Path.GetFileName(file))

module private FileAttributes =
    
    open System.IO

    let hasFlag flag file =
        let info = FileInfo(file)
        info.Attributes.HasFlag(flag)

module Exercise1 = 

    open System.IO
    open System.Text.RegularExpressions
    open Files
    open FileAttributes

    let find pattern dir =
        let re = Regex(pattern)
        getAllFilesIn dir
        |> Seq.filter (nameMatches re)
        |> Seq.filter (hasFlag FileAttributes.ReadOnly)