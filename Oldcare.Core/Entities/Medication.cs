﻿using System.ComponentModel.DataAnnotations.Schema;
using OldCare.Core.Entities;

[Table("Medication")]
public class Medication : Entity
{
    public PrescriptionItem PrescriptionItem { get; set; }
    public string COREN { get; set; }
    public DateTime MedicationDate { get; set; }
    public string Note { get; set; }
}

