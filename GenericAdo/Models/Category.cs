using AdoGenericServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericAdo.Models;

public class Category :BaseEntity
{
    [PrimaryKey]
    public int CategoryID { get; set; }
    public string CategoryName { get; set; } = null!;
    public string? Description { get; set; }
    public byte[]? Picture { get; set; }
}

public class Shipper : BaseEntity
{
    [PrimaryKey]
    public int ShipperID { get; set; }
    public string CompanyName { get; set; } = null!;
    public string? Phone { get; set; }
}
