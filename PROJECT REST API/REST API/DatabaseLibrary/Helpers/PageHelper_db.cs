using DatabaseLibrary.Core;
using DatabaseLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Net;
using System.Text;

namespace DatabaseLibrary.Helpers
{
    public class PageHelper_db
    {
        /// <summary>
        /// Adds a new instance into the database.
        /// </summary>
        public static Page_db Add(string topic, string content, string author,
            DbContext context, out StatusResponse statusResponse)
        {
            try
            {
                if (string.IsNullOrEmpty(topic?.Trim()))
                    throw new StatusException(HttpStatusCode.BadRequest, "Please provide a topic.");
                if (string.IsNullOrEmpty(content?.Trim()))
                    throw new StatusException(HttpStatusCode.BadRequest, "Please provide content.");
                if (string.IsNullOrEmpty(author?.Trim()))
                    throw new StatusException(HttpStatusCode.BadRequest, "Please provide an author.");

                //Generate a new instance
                Page_db instance = new Page_db
                (
                    id: Convert.ToInt32(Guid.NewGuid()),
                    topic, content, author
                );

                //Add to database
                int rowsAffected = context.ExecuteNonQueryCommand
                    (
                        commandText: "INSERT INTO pages (id, topic, content, author) values (@id, @topic, @content, @author)",
                        parameters: new Dictionary<string, object>()
                        {
                            { "@id", instance.Id },
                            { "@topic", instance.Topic },
                            { "@content", instance.Content },
                            { "@author", instance.Author }
                        },
                        message: out string message
                    );
                if (rowsAffected == -1)
                    throw new Exception(message);

                //Return value
                statusResponse = new StatusResponse("Page added successfully");
                return instance;
            }
            catch (Exception exception)
            {
                statusResponse = new StatusResponse(exception);
                return null;
            }
        }

        /// <summary>
        /// Retrieves specific instance
        /// </summary>
        public static Page_db GetPage(int id, string topic, string author,
            DbContext context, out StatusResponse statusResponse)
        {
            try
            {
                //Get from database
                DataTable table = context.ExecuteDataQueryCommand
                    (
                        commandText: "SELECT * FROM pages WHERE id = @id, topic = @topic, author = @author",
                        parameters: new Dictionary<string, object>()
                        {
                            { "@id", id },
                            { "@topic", topic },
                            { "@author", author }
                        },
                        message: out string message
                    );

                if (table == null)
                    throw new Exception(message);

                //Parse data
                Page_db instance = new Page_db();
                foreach (DataRow row in table.Rows)
                    instance = new Page_db
                        (
                            id: Convert.ToInt32(row["id"]),
                            topic: row["topic"].ToString(),
                            content: row["content"].ToString(),
                            author: row["author"].ToString()
                        );

                //Return value
                statusResponse = new StatusResponse("page successfully retrieved");
                return instance;
            }
            catch (Exception exception)
            {
                statusResponse = new StatusResponse(exception);
                return null;
            }
        }

        /// <summary>
        /// Deletes information of given client
        /// </summary>
        public static Page_db DeletePage(int id, string topic, string content, string author,
            DbContext context, out StatusResponse statusResponse)
        {
            try
            {
                // Delete from database
                DataTable table = context.ExecuteDataQueryCommand
                    (
                        commandText: "DELETE * FROM cardioLogs WHERE id = @id, topic = @topic, author = @author",
                        parameters: new Dictionary<string, object>()
                        {
                            { "@id", id },
                            { "@topic", topic },
                            { "@author", author }
                        },
                        message: out string message
                    );
                statusResponse = new StatusResponse("Page has been removed successfully.");
                return null;
            }
            catch (Exception exception)
            {
                statusResponse = new StatusResponse(exception);
                return null;
            }
        }

        public static Page_db EditPage(int id, string topic, string content, string author,
            DbContext context, out StatusResponse statusResponse)
        {
            try
            {
                // Edit from database
                DataTable table = context.ExecuteDataQueryCommand
                    (
                        commandText: "UPDATE cardioLogs SET content = @content, topic = @topic WHERE  id = @id, topic = @topic, author = @author",
                        parameters: new Dictionary<string, object>()
                        {
                            { "@id", id },
                            { "@topic", topic },
                            { "@author", author },
                            { "@content", content }
                        },
                        message: out string message
                    );
                statusResponse = new StatusResponse("Page has been updated successfully.");
                return null;
            }
            catch (Exception exception)
            {
                statusResponse = new StatusResponse(exception);
                return null;
            }
        }
    }
}