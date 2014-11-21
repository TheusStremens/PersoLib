CREATE TABLE `persolib`.`emp_emprestimo` (
  `emp_id` INT NOT NULL AUTO_INCREMENT,
  `emp_nome_emprestante` VARCHAR(45) NOT NULL,
  `emp_email_emprestante` VARCHAR(45) NOT NULL,
  `emp_data_devolucao` DATE NOT NULL,
  `emp_id_livro` INT NOT NULL,
  `emp_id_usuario` INT NOT NULL,
  PRIMARY KEY (`emp_id`),
  UNIQUE INDEX `emp_id_UNIQUE` (`emp_id` ASC),
  INDEX `fkId_Livro` (`emp_id_livro` ASC),
  INDEX `fkId_Usuario` (`emp_id_usuario` ASC),
  CONSTRAINT `fkEMP_Id_Livro`
    FOREIGN KEY (`emp_id_livro`)
    REFERENCES `persolib`.`lvr_livro` (`lvr_id`)
    ON DELETE CASCADE
    ON UPDATE CASCADE,
  CONSTRAINT `fkEMP_Id_Usuario`
    FOREIGN KEY (`emp_id_usuario`)
    REFERENCES `persolib`.`usr_usuario` (`USR_id`)
    ON DELETE CASCADE
    ON UPDATE CASCADE);