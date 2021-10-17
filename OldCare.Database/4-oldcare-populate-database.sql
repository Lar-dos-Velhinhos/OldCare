USE [oldcare]

BEGIN TRANSACTION

    INSERT INTO
        [Person]
    VALUES
    (
        '1db1dd66-e53d-4635-b527-a6f4ad9207b3',
        'Rua feminina',
        GETDATE(),
        'Guaratinguetá/SP',
        12345678,
        'Guaratinguetá',
        12345678912,
        'Centro',
        0,
        'Maria José Silva',
        'Não possui RG.',
        'maria-jose',
        null,
        'SP'
    ),
    (
        'd48dd998-41f8-46a4-9938-f6897d9eae89',
        'Rua masculina',
        GETDATE(),
        'Lorena/SP',
        87654321,
        'Cachoeira Paulista',
        12345678912,
        'Zona sul',
        1,
        'José Maria Silva',
        'Nada a declarar.',
        'jose-maria',
        123456789,
        'SP'
    ),
    (
        '8077cacb-da9d-492c-ab49-16563d1a9919',
        'Rua responsavel',
        GETDATE(),
        'São José dos Campos/SP',
        87654321,
        'Roseira',
        21643859241,
        'Centro',
        0,
        'Joaquina Maria dos Santos',
        null,
        'joaquina-maria-santos',
        201346754,
        'SP'
    )

    -- ################### --

    INSERT INTO
        [Bedroom]
    VALUES
    (
        'd82e70cb-2310-4c66-982b-6ae41e4e0418',
        2,
        0,
        001
    ),
    (
        '394e3c20-52f3-43a9-955d-34fd7d4ba0bd',
        2,
        1,
        100
    )

    -- ################### --

    INSERT INTO
        [Resident]
    VALUES
    (
        'ea8a8e8f-811a-403d-b981-3a2863b7244d',
        '1db1dd66-e53d-4635-b527-a6f4ad9207b3',
        'd82e70cb-2310-4c66-982b-6ae41e4e0418',
        GETDATE(),
        null,
        'Geraldo Silva Santos',
        'UNIMED',
        1,
        1,
        'Antonia Josefa Coelho',
        'anotação',
        'Costureira',
        1,
        920134675802018,
        920131276584618
    ),
    (
        'c15e76c9-9eee-4e5f-9ead-741610c4c02c',
        'd48dd998-41f8-46a4-9938-f6897d9eae89',
        '394e3c20-52f3-43a9-955d-34fd7d4ba0bd',
        GETDATE(),
        GETDATE(),
        'Marcos Oliveira Teodoro',
        'SULAMERICA',
        2,
        3,
        null,
        'anotação',
        'Pedreiro',
        2,
        920134675802018,
        920131276584618
    )

    -- ################### --

    INSERT INTO
        [Responsible]
    VALUES
    (
        '03deb470-7c1a-4aff-8623-21a9789b9dbe',
        '8077cacb-da9d-492c-ab49-16563d1a9919',
        1,
        920131276584618
    )

    -- ################### --

    INSERT INTO
        [ResidentResponsible]
    VALUES
    (
        '3f3c9a53-3fe9-46d5-860a-9c0e000afb78',
        'c15e76c9-9eee-4e5f-9ead-741610c4c02c',
        '03deb470-7c1a-4aff-8623-21a9789b9dbe',
        1,
        null,
        1,
        GETDATE()
    )

ROLLBACK