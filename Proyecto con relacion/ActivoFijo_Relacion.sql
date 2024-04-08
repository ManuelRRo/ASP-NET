USE [DB_ACTIVOFIJO]
GO

/****** Object:  Table [CAT].[TBL_ClasificacionActivoFijo]    Script Date: 08/04/2024 9:08:04 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [CAT].[TBL_ClasificacionActivoFijo](
	[IdClasificacionActivoFijo] [int] IDENTITY(1,1) NOT NULL,
	[IdEspecifico] [int] NOT NULL,
	[Codigo] [varchar](6) NOT NULL,
	[Descripcion] [varchar](50) NOT NULL,
 CONSTRAINT [PK_IdClasificacionActivoFijo] PRIMARY KEY CLUSTERED 
(
	[IdClasificacionActivoFijo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [CAT].[TBL_ClasificacionActivoFijo]  WITH CHECK ADD  CONSTRAINT [FK_TBL_ClasificacionActivoFijo_TBL_EspecificoGasto] FOREIGN KEY([IdEspecifico])
REFERENCES [CAT].[TBL_EspecificoGasto] ([IdEspecifico])
GO

ALTER TABLE [CAT].[TBL_ClasificacionActivoFijo] CHECK CONSTRAINT [FK_TBL_ClasificacionActivoFijo_TBL_EspecificoGasto]
GO


