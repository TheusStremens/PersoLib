CREATE TABLE `persolib`.`lvr_livro` (
  `lvr_id` INT NOT NULL AUTO_INCREMENT,
  `lvr_id_usuario` INT NOT NULL,
  `lvr_nome` VARCHAR(45) NOT NULL,
  `lvr_qtd_emprestada` INT NOT NULL,
  `lvr_qtd_disponivel` INT NOT NULL,
  PRIMARY KEY (`lvr_id`),
  UNIQUE INDEX `lvr_id_UNIQUE` (`lvr_id` ASC),
  INDEX `fk_Id_Usuario_idx` (`lvr_id_usuario` ASC),
  CONSTRAINT `fk_Id_Usuario`
    FOREIGN KEY (`lvr_id_usuario`)
    REFERENCES `persolib`.`usr_usuario` (`USR_id`)
    ON DELETE CASCADE
    ON UPDATE CASCADE);