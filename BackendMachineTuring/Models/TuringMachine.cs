using System;
using System.Collections.Generic;

namespace BackendMachineTuring.Models;

public partial class TuringMachine
{
    public int Id { get; set; }

    public string Estados { get; set; } = null!;

    public string EstadosFinales { get; set; } = null!;

    public string AlfabetoEntrada { get; set; } = null!;

    public string AlfabetoCinta { get; set; } = null!;

    public string Transiciones { get; set; } = null!;
}
