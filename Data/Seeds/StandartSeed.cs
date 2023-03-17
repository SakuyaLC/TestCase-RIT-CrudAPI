using System.Diagnostics.Metrics;
using TestCase_RIT_CrudAPI.Data.Context;
using TestCase_RIT_CrudAPI.Model;

namespace TestCase_RIT_CrudAPI.Data.Seeds
{
    public class StandartSeed
    {
        private readonly DataContext dataContext;
        public StandartSeed(DataContext context)
        {
            this.dataContext = context;
        }
        public void SeedDataContext()
        {
            if (!dataContext.DrillBlocks.Any())
            {
                var drillBlocks = new List<DrillBlock>()
                {
                    new DrillBlock()
                    {
                        Name = "DrillBlock1",
                        UpdateDate = DateTime.Now,
                        DrillBlockPoints = new List<DrillBlockPoint>()
                        {
                            new DrillBlockPoint()
                            {
                                Sequence = "Sequence1",
                                X = 1, Y = 2, Z = 3,
                            },

                            new DrillBlockPoint()
                            {
                                Sequence = "Sequence2",
                                X = 1, Y = 2, Z = 3,
                            },

                            new DrillBlockPoint()
                            {
                                Sequence = "Sequence3",
                                X = 1, Y = 2, Z = 3,
                            },
                        },
                        Holes = new List<Hole>()
                        {
                            new Hole()
                            {
                                Name = "Hole1",
                                Depth = 20,
                                HolePoints = new List<HolePoint>()
                                {
                                    new HolePoint()
                                    {
                                        X = 1, Y = 2, Z=3,
                                    },

                                    new HolePoint()
                                    {
                                        X = 1, Y = 2, Z=3,
                                    },

                                    new HolePoint()
                                    {
                                        X = 1, Y = 2, Z=3,
                                    },
                                }
                            },

                            new Hole()
                            {
                                Name = "Hole1",
                                Depth = 20,
                                HolePoints = new List<HolePoint>()
                                {
                                    new HolePoint()
                                    {
                                        X = 1, Y = 2, Z=3,
                                    },

                                    new HolePoint()
                                    {
                                        X = 1, Y = 2, Z=3,
                                    },

                                    new HolePoint()
                                    {
                                        X = 1, Y = 2, Z=3,
                                    },
                                }
                            },
                        }
                        
                    },
                    new DrillBlock()
                    {
                        Name = "DrillBlock2",
                        UpdateDate = DateTime.Now,
                        DrillBlockPoints = new List<DrillBlockPoint>()
                        {
                            new DrillBlockPoint()
                            {
                                Sequence = "Sequence1",
                                X = 1, Y = 2, Z = 3,
                            },

                            new DrillBlockPoint()
                            {
                                Sequence = "Sequence2",
                                X = 1, Y = 2, Z = 3,
                            },

                            new DrillBlockPoint()
                            {
                                Sequence = "Sequence3",
                                X = 1, Y = 2, Z = 3,
                            },
                        },
                        Holes = new List<Hole>()
                        {
                            new Hole()
                            {
                                Name = "Hole1",
                                Depth = 20,
                                HolePoints = new List<HolePoint>()
                                {
                                    new HolePoint()
                                    {
                                        X = 1, Y = 2, Z=3,
                                    },

                                    new HolePoint()
                                    {
                                        X = 1, Y = 2, Z=3,
                                    },

                                    new HolePoint()
                                    {
                                        X = 1, Y = 2, Z=3,
                                    },
                                }
                            },

                            new Hole()
                            {
                                Name = "Hole1",
                                Depth = 20,
                                HolePoints = new List<HolePoint>()
                                {
                                    new HolePoint()
                                    {
                                        X = 1, Y = 2, Z=3,
                                    },

                                    new HolePoint()
                                    {
                                        X = 1, Y = 2, Z=3,
                                    },

                                    new HolePoint()
                                    {
                                        X = 1, Y = 2, Z=3,
                                    },
                                }
                            },
                        }

                    },
                    new DrillBlock()
                    {
                        Name = "DrillBlock3",
                        UpdateDate = DateTime.Now,
                        DrillBlockPoints = new List<DrillBlockPoint>()
                        {
                            new DrillBlockPoint()
                            {
                                Sequence = "Sequence1",
                                X = 1, Y = 2, Z = 3,
                            },

                            new DrillBlockPoint()
                            {
                                Sequence = "Sequence2",
                                X = 1, Y = 2, Z = 3,
                            },

                            new DrillBlockPoint()
                            {
                                Sequence = "Sequence3",
                                X = 1, Y = 2, Z = 3,
                            },
                        },
                        Holes = new List<Hole>()
                        {
                            new Hole()
                            {
                                Name = "Hole1",
                                Depth = 20,
                                HolePoints = new List<HolePoint>()
                                {
                                    new HolePoint()
                                    {
                                        X = 1, Y = 2, Z=3,
                                    },

                                    new HolePoint()
                                    {
                                        X = 1, Y = 2, Z=3,
                                    },

                                    new HolePoint()
                                    {
                                        X = 1, Y = 2, Z=3,
                                    },
                                }
                            },

                            new Hole()
                            {
                                Name = "Hole1",
                                Depth = 20,
                                HolePoints = new List<HolePoint>()
                                {
                                    new HolePoint()
                                    {
                                        X = 1, Y = 2, Z=3,
                                    },

                                    new HolePoint()
                                    {
                                        X = 1, Y = 2, Z=3,
                                    },

                                    new HolePoint()
                                    {
                                        X = 1, Y = 2, Z=3,
                                    },
                                }
                            },
                        }

                    },
                    new DrillBlock()
                    {
                        Name = "DrillBlock4",
                        UpdateDate = DateTime.Now,
                        DrillBlockPoints = new List<DrillBlockPoint>()
                        {
                            new DrillBlockPoint()
                            {
                                Sequence = "Sequence1",
                                X = 1, Y = 2, Z = 3,
                            },

                            new DrillBlockPoint()
                            {
                                Sequence = "Sequence2",
                                X = 1, Y = 2, Z = 3,
                            },

                            new DrillBlockPoint()
                            {
                                Sequence = "Sequence3",
                                X = 1, Y = 2, Z = 3,
                            },
                        },
                        Holes = new List<Hole>()
                        {
                            new Hole()
                            {
                                Name = "Hole1",
                                Depth = 20,
                                HolePoints = new List<HolePoint>()
                                {
                                    new HolePoint()
                                    {
                                        X = 1, Y = 2, Z=3,
                                    },

                                    new HolePoint()
                                    {
                                        X = 1, Y = 2, Z=3,
                                    },

                                    new HolePoint()
                                    {
                                        X = 1, Y = 2, Z=3,
                                    },
                                }
                            },

                            new Hole()
                            {
                                Name = "Hole1",
                                Depth = 20,
                                HolePoints = new List<HolePoint>()
                                {
                                    new HolePoint()
                                    {
                                        X = 1, Y = 2, Z=3,
                                    },

                                    new HolePoint()
                                    {
                                        X = 1, Y = 2, Z=3,
                                    },

                                    new HolePoint()
                                    {
                                        X = 1, Y = 2, Z=3,
                                    },
                                }
                            },
                        }

                    },
                    new DrillBlock()
                    {
                        Name = "DrillBlock5",
                        UpdateDate = DateTime.Now,
                        DrillBlockPoints = new List<DrillBlockPoint>()
                        {
                            new DrillBlockPoint()
                            {
                                Sequence = "Sequence1",
                                X = 1, Y = 2, Z = 3,
                            },

                            new DrillBlockPoint()
                            {
                                Sequence = "Sequence2",
                                X = 1, Y = 2, Z = 3,
                            },

                            new DrillBlockPoint()
                            {
                                Sequence = "Sequence3",
                                X = 1, Y = 2, Z = 3,
                            },
                        },
                        Holes = new List<Hole>()
                        {
                            new Hole()
                            {
                                Name = "Hole1",
                                Depth = 20,
                                HolePoints = new List<HolePoint>()
                                {
                                    new HolePoint()
                                    {
                                        X = 1, Y = 2, Z=3,
                                    },

                                    new HolePoint()
                                    {
                                        X = 1, Y = 2, Z=3,
                                    },

                                    new HolePoint()
                                    {
                                        X = 1, Y = 2, Z=3,
                                    },
                                }
                            },

                            new Hole()
                            {
                                Name = "Hole1",
                                Depth = 20,
                                HolePoints = new List<HolePoint>()
                                {
                                    new HolePoint()
                                    {
                                        X = 1, Y = 2, Z=3,
                                    },

                                    new HolePoint()
                                    {
                                        X = 1, Y = 2, Z=3,
                                    },

                                    new HolePoint()
                                    {
                                        X = 1, Y = 2, Z=3,
                                    },
                                }
                            },
                        }

                    },
                };

                dataContext.AddRange(drillBlocks);
                dataContext.SaveChanges();
            }
        }
    }
}

