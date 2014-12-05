ALTER TABLE `persolib`.`lvr_livro` 
DROP COLUMN `lvr_qtd_disponivel`,
CHANGE COLUMN `lvr_qtd_emprestada` `lvr_emprestado` TINYINT(1) NOT NULL ;
