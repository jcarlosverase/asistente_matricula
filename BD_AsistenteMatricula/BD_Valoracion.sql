USE [BD_Valoracion]
GO
/****** Object:  Table [dbo].[Valoracion]    Script Date: 08/04/2019 05:26:02 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Valoracion](
	[IdValoracion] [varchar](50) NOT NULL,
	[Calificacion] [int] NULL,
	[Curso] [varchar](50) NULL,
	[Docente] [varchar](50) NULL,
	[Fecha] [datetime] NULL,
 CONSTRAINT [PK_Valoracion] PRIMARY KEY CLUSTERED 
(
	[IdValoracion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Valoracion] ([IdValoracion], [Calificacion], [Curso], [Docente], [Fecha]) VALUES (N'V001', 5, N'Fisica 1', N'Juan ramos', CAST(N'2019-04-04T00:00:00.000' AS DateTime))
INSERT [dbo].[Valoracion] ([IdValoracion], [Calificacion], [Curso], [Docente], [Fecha]) VALUES (N'V002', 4, N'Fisica 1', N'Cesar Perez', CAST(N'2019-04-04T00:00:00.000' AS DateTime))
INSERT [dbo].[Valoracion] ([IdValoracion], [Calificacion], [Curso], [Docente], [Fecha]) VALUES (N'V003', 3, N'Fisica 1', N'Julio Reyes', CAST(N'2019-04-04T00:00:00.000' AS DateTime))
INSERT [dbo].[Valoracion] ([IdValoracion], [Calificacion], [Curso], [Docente], [Fecha]) VALUES (N'V004', 2, N'Fisica 1', N'Andy Borja', CAST(N'2019-04-04T00:00:00.000' AS DateTime))
INSERT [dbo].[Valoracion] ([IdValoracion], [Calificacion], [Curso], [Docente], [Fecha]) VALUES (N'V005', 1, N'Fisica 1', N'Feliz Taya', CAST(N'2019-04-04T00:00:00.000' AS DateTime))
INSERT [dbo].[Valoracion] ([IdValoracion], [Calificacion], [Curso], [Docente], [Fecha]) VALUES (N'V006', 4, N'Algoritmos', N'Juan ramos', CAST(N'2019-03-03T00:00:00.000' AS DateTime))
INSERT [dbo].[Valoracion] ([IdValoracion], [Calificacion], [Curso], [Docente], [Fecha]) VALUES (N'V007', 3, N'Algoritmos', N'Cesar Perez', CAST(N'2019-03-03T00:00:00.000' AS DateTime))
INSERT [dbo].[Valoracion] ([IdValoracion], [Calificacion], [Curso], [Docente], [Fecha]) VALUES (N'V008', 2, N'Algoritmos', N'Julio Reyes', CAST(N'2019-03-03T00:00:00.000' AS DateTime))
INSERT [dbo].[Valoracion] ([IdValoracion], [Calificacion], [Curso], [Docente], [Fecha]) VALUES (N'V009', 1, N'Algoritmos', N'Andy Borja', CAST(N'2019-03-03T00:00:00.000' AS DateTime))
