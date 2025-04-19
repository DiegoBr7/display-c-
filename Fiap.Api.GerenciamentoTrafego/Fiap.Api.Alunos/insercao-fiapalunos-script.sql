DELETE FROM "PF0954"."PedidoProduto";
DELETE FROM "PF0954"."Pedidos";
DELETE FROM "PF0954"."Produtos";
DELETE FROM "PF0954"."Clientes";
DELETE FROM "PF0954"."Lojas";
DELETE FROM "PF0954"."Fornecedores";
DELETE FROM "PF0954"."Representantes";

-- Inserção de dados para a tabela de Representantes
INSERT INTO "PF0954"."Representantes" ("RepresentanteId", "NomeRepresentante", "Cpf") VALUES (100, 'João da Silva', '123.456.789-00');
INSERT INTO "PF0954"."Representantes" ("RepresentanteId", "NomeRepresentante", "Cpf") VALUES (101, 'Maria Fernanda', '234.567.890-11');
INSERT INTO "PF0954"."Representantes" ("RepresentanteId", "NomeRepresentante", "Cpf") VALUES (102, 'Carlos Eduardo', '345.678.901-22');
INSERT INTO "PF0954"."Representantes" ("RepresentanteId", "NomeRepresentante", "Cpf") VALUES (103, 'Ana Carolina', '456.789.012-33');
INSERT INTO "PF0954"."Representantes" ("RepresentanteId", "NomeRepresentante", "Cpf") VALUES (104, 'Pedro Alcântara', '567.890.123-44');

-- Inserção de dados para a tabela de Clientes
INSERT INTO "PF0954"."Clientes" ("ClienteId", "Nome", "Email", "DataNascimento", "RepresentanteId") VALUES (100, 'Carlos Silva', 'carlos.silva@email.com', TO_DATE('1985-07-20', 'YYYY-MM-DD'), 100);
INSERT INTO "PF0954"."Clientes" ("ClienteId", "Nome", "Email", "DataNascimento", "RepresentanteId") VALUES (101, 'Maria Oliveira', 'maria.oliveira@email.com', TO_DATE('1990-08-15', 'YYYY-MM-DD'), 101);
INSERT INTO "PF0954"."Clientes" ("ClienteId", "Nome", "Email", "DataNascimento", "RepresentanteId") VALUES (102, 'João Costa', 'joao.costa@email.com', TO_DATE('1975-09-30', 'YYYY-MM-DD'), 102);
INSERT INTO "PF0954"."Clientes" ("ClienteId", "Nome", "Email", "DataNascimento", "RepresentanteId") VALUES (103, 'Ana Beatriz', 'ana.beatriz@email.com', TO_DATE('1980-05-25', 'YYYY-MM-DD'), 103);
INSERT INTO "PF0954"."Clientes" ("ClienteId", "Nome", "Email", "DataNascimento", "RepresentanteId") VALUES (104, 'Pedro Alves', 'pedro.alves@email.com', TO_DATE('1995-12-10', 'YYYY-MM-DD'), 104);

-- Inserção de dados para a tabela de Lojas
INSERT INTO "PF0954"."Lojas" ("LojaId", "Nome", "Endereco") VALUES (100, 'Loja Central', 'Rua das Flores, 123');
INSERT INTO "PF0954"."Lojas" ("LojaId", "Nome", "Endereco") VALUES (101, 'Loja Sul', 'Av. Brasil, 999');
INSERT INTO "PF0954"."Lojas" ("LojaId", "Nome", "Endereco") VALUES (102, 'Loja Norte', 'Av. dos Estados, 501');
INSERT INTO "PF0954"."Lojas" ("LojaId", "Nome", "Endereco") VALUES (103, 'Loja Leste', 'Rua do Sol, 400');
INSERT INTO "PF0954"."Lojas" ("LojaId", "Nome", "Endereco") VALUES (104, 'Loja Oeste', 'Av. das Américas, 1800');

-- Inserção de dados para a tabela de Fornecedores
INSERT INTO "PF0954"."Fornecedores" ("FornecedorId", "Nome") VALUES (100, 'ABC Suprimentos');
INSERT INTO "PF0954"."Fornecedores" ("FornecedorId", "Nome") VALUES (101, 'Distribuidora Sol');
INSERT INTO "PF0954"."Fornecedores" ("FornecedorId", "Nome") VALUES (102, 'TechParts');
INSERT INTO "PF0954"."Fornecedores" ("FornecedorId", "Nome") VALUES (103, 'Indústrias Químicas Reunidas');
INSERT INTO "PF0954"."Fornecedores" ("FornecedorId", "Nome") VALUES (104, 'Equipamentos Eficientes');

-- Inserção de dados para a tabela de Produtos
INSERT INTO "PF0954"."Produtos" ("ProdutoId", "Nome", "Descricao", "Preco", "FornecedorId") VALUES (100, 'Teclado Mecânico', 'Teclado gamer RGB', 150.00, 102);
INSERT INTO "PF0954"."Produtos" ("ProdutoId", "Nome", "Descricao", "Preco", "FornecedorId") VALUES (101, 'Mouse Óptico', 'Mouse óptico com precisão para design', 120.00, 102);
INSERT INTO "PF0954"."Produtos" ("ProdutoId", "Nome", "Descricao", "Preco", "FornecedorId") VALUES (102, 'Monitor LED 24''', 'Monitor LED com resolução full HD', 700.00, 100);
INSERT INTO "PF0954"."Produtos" ("ProdutoId", "Nome", "Descricao", "Preco", "FornecedorId") VALUES (103, 'Cadeira Gamer', 'Cadeira ergonômica para longas sessões', 300.00, 104);
INSERT INTO "PF0954"."Produtos" ("ProdutoId", "Nome", "Descricao", "Preco", "FornecedorId") VALUES (104, 'Impressora Multifuncional', 'Impressora multifuncional laser colorida', 800.00, 101);

-- Inserção de dados para a tabela de Pedidos
INSERT INTO "PF0954"."Pedidos" ("PedidoId", "DataPedido", "ClienteId", "LojaId") VALUES (100, TO_DATE('2023-01-15', 'YYYY-MM-DD'), 100, 100);
INSERT INTO "PF0954"."Pedidos" ("PedidoId", "DataPedido", "ClienteId", "LojaId") VALUES (101, TO_DATE('2023-02-20', 'YYYY-MM-DD'), 101, 101);
INSERT INTO "PF0954"."Pedidos" ("PedidoId", "DataPedido", "ClienteId", "LojaId") VALUES (102, TO_DATE('2023-03-25', 'YYYY-MM-DD'), 102, 102);
INSERT INTO "PF0954"."Pedidos" ("PedidoId", "DataPedido", "ClienteId", "LojaId") VALUES (103, TO_DATE('2023-04-30', 'YYYY-MM-DD'), 103, 103);
INSERT INTO "PF0954"."Pedidos" ("PedidoId", "DataPedido", "ClienteId", "LojaId") VALUES (104, TO_DATE('2023-05-05', 'YYYY-MM-DD'), 104, 104);

-- Inserção de dados para a tabela de PedidoProduto
INSERT INTO "PF0954"."PedidoProdutos" ("PedidoId", "ProdutoId") VALUES (100, 100);
INSERT INTO "PF0954"."PedidoProdutos" ("PedidoId", "ProdutoId") VALUES (100, 101);
INSERT INTO "PF0954"."PedidoProdutos" ("PedidoId", "ProdutoId") VALUES (101, 102);
INSERT INTO "PF0954"."PedidoProdutos" ("PedidoId", "ProdutoId") VALUES (101, 103);
INSERT INTO "PF0954"."PedidoProdutos" ("PedidoId", "ProdutoId") VALUES (101, 104);
INSERT INTO "PF0954"."PedidoProdutos" ("PedidoId", "ProdutoId") VALUES (102, 100);
INSERT INTO "PF0954"."PedidoProdutos" ("PedidoId", "ProdutoId") VALUES (102, 101);
INSERT INTO "PF0954"."PedidoProdutos" ("PedidoId", "ProdutoId") VALUES (102, 103);
INSERT INTO "PF0954"."PedidoProdutos" ("PedidoId", "ProdutoId") VALUES (103, 101);
INSERT INTO "PF0954"."PedidoProdutos" ("PedidoId", "ProdutoId") VALUES (103, 102);
INSERT INTO "PF0954"."PedidoProdutos" ("PedidoId", "ProdutoId") VALUES (103, 104);
INSERT INTO "PF0954"."PedidoProdutos" ("PedidoId", "ProdutoId") VALUES (104, 100);
INSERT INTO "PF0954"."PedidoProdutos" ("PedidoId", "ProdutoId") VALUES (104, 102);
INSERT INTO "PF0954"."PedidoProdutos" ("PedidoId", "ProdutoId") VALUES (104, 103);
INSERT INTO "PF0954"."PedidoProdutos" ("PedidoId", "ProdutoId") VALUES (104, 104);

COMMIT;



DECLARE
    v_base_year NUMBER := 1970;
BEGIN
    FOR i IN 150 .. 299 LOOP
        INSERT INTO "PF0954"."Clientes" (
            "ClienteId", 
            "Nome", 
            "Email", 
            "DataNascimento", 
            "RepresentanteId"
        ) VALUES (
            i, 
            'Cliente ' || TO_CHAR(i), 
            'cliente' || TO_CHAR(i) || '@email.com', 
            TO_DATE(v_base_year + MOD(i, 30) || '-01-01', 'YYYY-MM-DD'),  -- Random year from 1970 to 2000
            100 + MOD(i, 5)  -- Cycles through IDs 100 to 104
        );
    END LOOP;
    COMMIT;
END;



