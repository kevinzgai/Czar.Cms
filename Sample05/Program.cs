using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
namespace Sample05
{
    class Program
    {
        static void Main(string[] args)
        {
            //test_insert();
            //test_mult_insert();
            //test_del();
            //test_mult_del();
            //test_update();
            //test_mult_update();
            //test_select_one();
            //test_mult_select_list();
            test_select_content_with_comment();
        }

        /// <summary>
        /// 测试单条插入
        /// </summary>
        static void test_insert()
        {
            var content = new Content()
            {
                title = "标题1",
                content = "内容1"
            };
            using (var conn =
                new SqlConnection(
                    "Data Source=192.168.8.36;User ID=sa;Password=bt6VI9D3GZ8;Initial Catalog=k_Movie;Pooling=true;Max Pool Size=100;")
            )
            {
                string sql_insert =
                    @"INSERT INTO [content]
                            ([title],[content],[status],[add_time],[modify_time])
                 VALUES (@title, @content,@status,@add_time,@modify_time)";
                var result = conn.Execute(sql_insert, content);
                Console.WriteLine($"test_insert:插入了{result}条数据！");
            }
        }

        /// <summary>
        /// 批量添加
        /// </summary>
        static void test_mult_insert()
        {
            var contents = new List<Content>()
            {
                new Content()
                {
                    title = "批量插入标题1",
                    content = "批量插入内容1"
                },
                new Content()
                {
                    title = "批量插入标题2",
                    content = "批量插入内容2"
                },
            };
            using (var conn =
                new SqlConnection(
                    "Data Source=192.168.8.36;User ID=sa;Password=bt6VI9D3GZ8;Initial Catalog=k_Movie;Pooling=true;Max Pool Size=100;")
            )
            {
                string sql_insert =
                    @"INSERT INTO [content]
                            ([title],[content],[status],[add_time],[modify_time])
                 VALUES (@title, @content,@status,@add_time,@modify_time)";
                var result = conn.Execute(sql_insert, contents);
                Console.WriteLine($"test_mult_insert:批量插入了{result}条数据！");
            }
        }

        /// <summary>
        /// 单条删除
        /// </summary>
        static void test_del()
        {
            var content = new Content()
            {
                id = 2
            };
            using (var conn =
                new SqlConnection(
                    "Data Source=192.168.8.36;User ID=sa;Password=bt6VI9D3GZ8;Initial Catalog=k_Movie;Pooling=true;Max Pool Size=100;")
            )
            {
                string sql_del = @"delete from [content] where (id=@id)";
                var result = conn.Execute(sql_del, content);
                Console.WriteLine($"test_del:删除了{result}条数据！");
            }
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        static void test_mult_del()
        {
            var contents = new List<Content>()
            {
                new Content()
                {
                    id = 1
                },
                new Content()
                {
                    id = 4
                }
            };
            using (var conn =
                new SqlConnection(
                    "Data Source=192.168.8.36;User ID=sa;Password=bt6VI9D3GZ8;Initial Catalog=k_Movie;Pooling=true;Max Pool Size=100;")
            )
            {
                string sql_del = @"delete from [content] where (id=@id)";
                var result = conn.Execute(sql_del, contents);
                Console.WriteLine($"test_del:删除了{result}条数据！");
            }
        }

        /// <summary>
        /// 单条修改
        /// </summary>
        static void test_update()
        {
            var content = new Content()
            {
                id = 3,
                title = "单条插入标题3", content = "单条插入标题内容3"
            };
            using (var conn =
                new SqlConnection(
                    "Data Source=192.168.8.36;User ID=sa;Password=bt6VI9D3GZ8;Initial Catalog=k_Movie;Pooling=true;Max Pool Size=100;")
            )
            {
                string sql_del =
                    @"update [content] set title=@title,[content]=@content,modify_time=GETDATE() where (id=@id)";
                var result = conn.Execute(sql_del, content);
                Console.WriteLine($"test_del:修改了{result}条数据！");
            }
        }

        /// <summary>
        /// 批量修改
        /// </summary>
        static void test_mult_update()
        {
            var contents = new List<Content>()
            {
                new Content()
                {
                    id = 5,
                    title = "单条插入标题5", content = "单条插入标题内容5"
                },
                new Content()
                {
                    id = 6,
                    title = "单条插入标题6", content = "单条插入标题内容6"
                }
            };
            using (var conn =
                new SqlConnection(
                    "Data Source=192.168.8.36;User ID=sa;Password=bt6VI9D3GZ8;Initial Catalog=k_Movie;Pooling=true;Max Pool Size=100;")
            )
            {
                string sql_del =
                    @"update [content] set title=@title,[content]=@content,modify_time=GETDATE() where (id=@id)";
                var result = conn.Execute(sql_del, contents);
                Console.WriteLine($"test_del:修改了{result}条数据！");
            }
        }

        /// <summary>
        /// 单条查询
        /// </summary>
        static void test_select_one()
        {
            using (var conn =
                new SqlConnection(
                    "Data Source=192.168.8.36;User ID=sa;Password=bt6VI9D3GZ8;Initial Catalog=k_Movie;Pooling=true;Max Pool Size=100;")
            )
            {
                string sql_sel = @"select * from [content] where id=@id";
                var result = conn.QueryFirstOrDefault<Content>(sql_sel, new {id = 5});
                Console.WriteLine($"test_del:查到的数据为：{result.title}");
            }
        }

        static void test_mult_select_list()
        {
            using (var conn =
                new SqlConnection(
                    "Data Source=192.168.8.36;User ID=sa;Password=bt6VI9D3GZ8;Initial Catalog=k_Movie;Pooling=true;Max Pool Size=100;")
            )
            {
                string sql_sel = @"select * from [content] where id in @ids";
                var result = conn.Query<Content>(sql_sel,new {ids=new int[] {6, 7, 8}});
                Console.WriteLine($"test_del:查询到了{result.Count()}条数据！");
            }
        }

        static void test_select_content_with_comment()
        {
            using (var conn =
                new SqlConnection(
                    "Data Source=192.168.8.36;User ID=sa;Password=bt6VI9D3GZ8;Initial Catalog=k_Movie;Pooling=true;Max Pool Size=100;")
            )
            {
                string str_sql = @"select * from [content] where id=@id;select * from [comment] where content_id=@id";
                using (var result=conn.QueryMultiple(str_sql,new{id=5}))
                {
                    var content = result.ReadFirstOrDefault<ContentWithCommnet>();
                    content.comments = result.Read<Comment>();
                    Console.WriteLine($"test_select_content_with_commnet:内容5的评论数量为{content.comments.Count()}");
                }
            }
        }
    }
}