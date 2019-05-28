﻿using System;
using Hangfire.MySql.Core;

namespace Hangfire.Tags.Mysql
{
    public static class GlobalConfigurationExtensions
    {
        /// <summary>
        /// Configures Hangfire to use Tags.
        /// </summary>
        /// <param name="configuration">Global configuration</param>
        /// <param name="options">Options for tags</param>
        /// <param name="sqlOptions">Options for mysql storage</param>
        /// <returns></returns>
        public static IGlobalConfiguration UseTagsWithMysql(this IGlobalConfiguration configuration, TagsOptions options = null, MySqlStorageOptions sqlOptions = null)
        {
            options = options ?? new TagsOptions();
            sqlOptions = sqlOptions ?? new MySqlStorageOptions();

            options.Storage = new MysqlTagsServiceStorage(sqlOptions);
            var config = configuration.UseTags(options);
            return config;
        }
    }
}
