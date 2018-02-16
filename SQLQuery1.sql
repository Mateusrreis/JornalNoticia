select idPublicacao from imagens
select SCOPE_IDENTITY() from Publicação
select * from Publicação
select idPublicacao from Publicação where idPublicacao = 1
insert into Publicação(titulo,CorpoNoticia,idCategoria,idArea,DtaPublicacao) values('Teste','testandoo envio de teste do corpo noticia',(select idCategoria from Categoria where idCategoria = 1),(select idArea from Area where idArea = 1),(GETDATE()));SELECT CAST(scope_identity() AS int)


Delete from Publicação
select top 3 p.idPublicacao,c.tipCategoria,p.DtaPublicacao,a.NomeArea,p.titulo,p.Corponoticia,i.caminhoimg,i.tipoimg from Publicação p, imagens i,Area a,Categoria c where i.idPublicacao = p.idPublicacao and a.idArea = p.idArea and c.idCategoria = p.idCategoria

select usuarioRev,senha from Revisores_Adm where usuarioRev='Matheus' and senha='Gengar38'