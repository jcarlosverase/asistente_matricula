USE [BD_Seguridad]
GO
/****** Object:  Table [dbo].[Universidad]    Script Date: 08/04/2019 05:25:28 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Universidad](
	[RUC] [varchar](11) NOT NULL,
	[RazonSocial] [varchar](250) NULL,
	[FlgActivo] [bit] NULL,
 CONSTRAINT [PK_Universidad_1] PRIMARY KEY CLUSTERED 
(
	[RUC] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UniversidadUsuario]    Script Date: 08/04/2019 05:25:28 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UniversidadUsuario](
	[Correo] [varchar](100) NOT NULL,
	[RUC] [varchar](11) NULL,
	[Nombre] [varchar](100) NULL,
	[Apellido] [varchar](100) NULL,
	[Contrasenia] [varchar](max) NULL,
	[FlgActivo] [bit] NULL,
 CONSTRAINT [PK_UniversidadUsuario_1] PRIMARY KEY CLUSTERED 
(
	[Correo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[Universidad] ([RUC], [RazonSocial], [FlgActivo]) VALUES (N'12345678912', N'Universidad Peruana de Ciencias Aplicadas', 1)
INSERT [dbo].[UniversidadUsuario] ([Correo], [RUC], [Nombre], [Apellido], [Contrasenia], [FlgActivo]) VALUES (N'abel@upc.edu.pe', N'12345678912', N'Abel', N'Quispe Orellana', N'qpdt7HVuZ/tLP/RXfGiLgM/iVD2Uw1BhSuAe1+IHS40P1ebvxUwja91zWt6QLqZzD8MVdADtMkQUtjM5Dp629/rRpOW5BKBzSlwpm27R0IjJM83uYOw5SQu2RASNsRT7zfQjCQesPNoCijyt8Nos4BgT/ghir1SNrlnTBHv1b4k=', 1)
INSERT [dbo].[UniversidadUsuario] ([Correo], [RUC], [Nombre], [Apellido], [Contrasenia], [FlgActivo]) VALUES (N'orellana@upc.edu.pe', N'12345678912', N'Alfredo', N'Orellana', N'1RYbBcTv8+s2bpB9ZitaoSNmtR1MB8pGmw5Y54DzlVAiJPvoKCAgnxwEWJYX+v5C4MLAzPFQ2qMBPNKAqZecr4tnViY5KGVhYD3BQ1IF5uT46SMFW7l+y8PlZBRwdRU3AFFJ1OWoPjom2dAZQYkgZlNV5r065D624XFsjOvZVgk=', 1)
ALTER TABLE [dbo].[UniversidadUsuario]  WITH CHECK ADD  CONSTRAINT [FK_UniversidadUsuario_Universidad] FOREIGN KEY([RUC])
REFERENCES [dbo].[Universidad] ([RUC])
GO
ALTER TABLE [dbo].[UniversidadUsuario] CHECK CONSTRAINT [FK_UniversidadUsuario_Universidad]
GO
