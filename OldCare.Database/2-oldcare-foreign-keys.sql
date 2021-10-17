USE [oldcare]
GO

BEGIN TRANSACTION

    ALTER TABLE [Resident]
        ADD CONSTRAINT [fk_resident_person] FOREIGN KEY ([PersonId])
            REFERENCES [Person] ([Id]);
    GO

    ALTER TABLE [Resident]
        ADD CONSTRAINT [fk_resident_bedroom] FOREIGN KEY ([BedroomId])
            REFERENCES [Bedroom] ([Id]);
    GO

    ALTER TABLE [Responsible]
        ADD CONSTRAINT [fk_responsible_person] FOREIGN KEY ([PersonId])
            REFERENCES [Person] ([Id]);
    GO

    ALTER TABLE [ResidentResponsible]
        ADD CONSTRAINT [fk_rr_resident] FOREIGN KEY ([ResidentId])
            REFERENCES [Resident] ([Id])
    GO

    ALTER TABLE [ResidentResponsible]
        ADD CONSTRAINT [fk_rr_responsible] FOREIGN KEY ([ResponsibleId])
            REFERENCES [Responsible] ([Id])
    GO

    ALTER TABLE [Occurrence]
        ADD CONSTRAINT [fk_occurrence_bedroom] FOREIGN KEY ([ResidentId])
            REFERENCES [Resident] ([Id]);
    GO

    ALTER TABLE [Prescription]
        ADD CONSTRAINT [fk_prescription_resident] FOREIGN KEY ([ResidentId])
            REFERENCES [Resident] ([Id]);
    GO

    ALTER TABLE [PrescriptionItem]
        ADD CONSTRAINT [fk_prescriptionitem_prescription] FOREIGN KEY ([PrescriptionId])
            REFERENCES [Prescription] ([Id])
    GO

    ALTER TABLE [PrescriptionItem]
        ADD CONSTRAINT [fk_prescriptionitem_Product] FOREIGN KEY ([ProductId])
            REFERENCES [Product] ([Id])
    GO

    ALTER TABLE [Medication]
        ADD CONSTRAINT [fk_medication_prescriptionitem] FOREIGN KEY ([PrescriptionItemId])
            REFERENCES [PrescriptionItem] ([Id])
    GO

ROLLBACK