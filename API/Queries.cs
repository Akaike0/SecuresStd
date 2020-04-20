using System;
using GraphQL;

namespace SecuresStd.API
{
    internal class Queries
    {
        // Protected
        public GraphQLRequest PROJECTS()
        {
            return new GraphQLRequest
            {
                Query = @"
                {
                    projects {
                        id
                        name
                        online
                        presets {
                            id
                            name
                            deviceLimit
                            sessionLimit
                            expireTime
                            expireFormat
                            tags
                            project {
                                id
                            }
                        }
                        licences {
                            id
                            owner
                            key
                            validFrom
                            expireAt
                            deviceLimit
                            sessionLimit
                            tags
                            sessions {
                                id
                                sessionID
                                device
                                licence {id}
                                updatedAt
                                createdAt
                            }
                            project {id}
                        }
                        lastLicence {
                            id
                        }
                        user {
                            id
                        }
                        createdAt
                    }
                }"
            };
        }

        public GraphQLRequest LICENCEBYKEY(string projectID, string key)
        {
            return new GraphQLRequest
            {
                Query = @"
                query licenceByKey (
                    $project: ID!
                    $key: String!
                ) {
                    licenceByKey(
                        project: $project
                        key: $key
                    )
                    {
                        id
                        owner
                        key
                        validFrom
                        expireAt
                        deviceLimit
                        sessionLimit
                        tags
                        sessions {
                            id
                            sessionID
                            device
                            licence {id}
                            updatedAt
                            createdAt
                        }
                        project {id}
                    }
                }",
                OperationName = "",
                Variables = new
                {
                    key,
                    project = projectID
                }
            };
        }
    }
}
