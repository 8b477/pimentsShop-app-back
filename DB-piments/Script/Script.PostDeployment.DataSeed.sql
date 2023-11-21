/*
Modèle de script de post-déploiement							
--------------------------------------------------------------------------------------
 Ce fichier contient des instructions SQL qui seront ajoutées au script de compilation.		
 Utilisez la syntaxe SQLCMD pour inclure un fichier dans le script de post-déploiement.			
 Exemple :      :r .\monfichier.sql								
 Utilisez la syntaxe SQLCMD pour référencer une variable dans le script de post-déploiement.		
 Exemple :      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
INSERT INTO Piments ([Name], [Category], [Description], [Price], [ScovilleScale])
VALUES 
  ('Carolina Reaper', 'Extrême', 'blabla super piment blabla', 5.00, '1,641,183 SHU'),
  ('Jalapeño', 'Doux', 'blabla super piment blabla', 0.75, '2,500 - 8,000 SHU'),
  ('Habanero', 'Hot', 'blabla super piment blabla', 1.50, '100,000 - 350,000 SHU'),
  ('Ghost Pepper', 'Hot', 'blabla super piment blabla', 2.00, '855,000 - 1,041,427 SHU'),
  ('Piment de Cayenne', 'Modéré', 'blabla super piment blabla', 0.50, '30,000 - 50,000 SHU'),
  ('Poblano', 'Doux', 'blabla super piment blabla', 1.25, '1,000 - 2,000 SHU'),
  ('Anaheim', 'Doux', 'blabla super piment blabla', 1.00, '500 - 2,500 SHU'),
  ('Serrano', 'Modéré', 'blabla super piment blabla', 0.75, '10,000 - 25,000 SHU'),
  ('Scotch Bonnet', 'Hot', 'blabla super piment blabla', 1.75, '80,000 - 400,000 SHU'),
  ('Thai Bird Chili', 'Hot', 'blabla super piment blabla', 1.50, '50,000 - 100,000 SHU'),
  ('Aji Amarillo', 'Modéré', 'blabla super piment blabla', 2.50, '30,000 - 50,000 SHU'),
  ('Red Cherry Pepper', 'Doux', 'blabla super piment blabla', 0.50, '0 - 1,000 SHU'),
  ('Cascabel', 'Doux', 'blabla super piment blabla', 2.00, '1,000 - 3,000 SHU'),
  ('Cherry Bomb', 'Modéré', 'blabla super piment blabla', 1.00, '2,500 - 5,000 SHU'),
  ('Pasilla', 'Modéré', 'blabla super piment blabla', 1.25, '1,000 - 2,000 SHU'),
  ('Banana Pepper', 'Doux', 'blabla super piment blabla', 0.75, '0 - 500 SHU'),
  ('Fresno', 'Modéré', 'blabla super piment blabla', 1.50, '2,500 - 10,000 SHU'),
  ('Aji Limon', 'Modéré', 'blabla super piment blabla', 2.25, '30,000 - 50,000 SHU'),
  ('Hungarian Wax', 'Modéré', 'blabla super piment blabla', 1.25, '5,000 - 10,000 SHU'),
  ('Trinidad Moruga Scorpion', 'Extrême', 'blabla super piment blabla', 3.00, '1,200,000 - 2,009,231 SHU');
