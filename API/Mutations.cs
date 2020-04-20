using System;
using GraphQL;
using SecuresStd.Models;

namespace SecuresStd.API
{
    internal class Mutations
    {
        // Protected
        public GraphQLRequest USE_API(string apiKey)
        {
            return new GraphQLRequest
            {
                Query = @"
                mutation useAPI($apiKey: String!) {
                    useAPI(apiKey: $apiKey) {
                        id
                        name
                    }
                }",
                OperationName = "",
                Variables = new
                {
                    apiKey
                }
            };
        }

        public GraphQLRequest CREATE_LICENCE(string owner, string key, DateTime validFrom, int expireTime, string expireFormat, int deviceLimit, int sessionLimit, string[] tags, string projectID)
        {
            return new GraphQLRequest
            {
                Query = @"
                mutation createLicence(
                    $owner: String!
                    $key: String!
                    $validFrom: String!
                    $expireTime: Number!
                    $expireFormat: String!
                    $deviceLimit: Number!
                    $sessionLimit: Number!
                    $tags: [String]!
                    $project: ID!
                ) {
                    createLicence(
                        owner: $owner
                        key: $key
                        validFrom: $validFrom
                        expireTime: $expireTime
                        expireFormat: $expireFormat
                        deviceLimit: $deviceLimit
                        sessionLimit: $sessionLimit
                        tags: $tags
                        project: $project
                    ) {
                        id
                        owner
                        key
                        validFrom
                        expireAt
                        deviceLimit
                        sessionLimit
                        tags
                        project {id}
                    }
                }",
                OperationName = "",
                Variables = new
                {
                    owner,
                    key,
                    validFrom = validFrom.ToString(),
                    expireTime,
                    expireFormat,
                    deviceLimit,
                    sessionLimit,
                    tags,
                    project = projectID
                }
            };
        }

        // Protected
        public GraphQLRequest UPDATE_LICENCE(string id, string owner, string key, DateTime validFrom, DateTime expireAt, int deviceLimit, int sessionLimit, string[] tags, string projectID)
        {
            return new GraphQLRequest
            {
                Query = @"
                    mutation updateLicence(
                        $id: ID!
                        $key: String!
                        $owner: String!
                        $validFrom: Date!
                        $expireAt: Date!
                        $deviceLimit: Number!
                        $sessionLimit: Number!
                        $tags: [String]!
                    ) {
                        updateLicence(
                            id: $id
                            key: $key
                            owner: $owner
                            validFrom: $validFrom
                            expireAt: $expireAt
                            deviceLimit: $deviceLimit
                            sessionLimit: $sessionLimit
                            tags: $tags
                        )
                    }
                ",
                OperationName = "",
                Variables = new
                {
                    id,
                    owner,
                    key,
                    validFrom = validFrom.ToString(),
                    expireAt = expireAt.ToString(),
                    deviceLimit,
                    sessionLimit,
                    tags,
                }
            };
        }

        // Protected
        public GraphQLRequest DELETE_LICENCE(string key, string projectID)
        {
            return new GraphQLRequest
            {
                Query = @"
                    mutation deleteLicence($key: String!, $project: ID!) {
                        deleteLicence(key: $key, project: $project)
                    }
                ",
                OperationName = "",
                Variables = new
                {
                    key,
                    project = projectID
                }
            };
        }

        // Protected
        public GraphQLRequest CREATE_PRESET(string name, int expireTime, string expireFormat, int deviceLimit, int sessionLimit, string[] tags, string projectID)
        {
            return new GraphQLRequest
            {
                Query = @"
                    mutation createPreset(
                        $name: String!
                        $expireTime: Number!
                        $expireFormat: String!
                        $deviceLimit: Number!
                        $sessionLimit: Number!
                        $tags: [String]!
                        $project: ID!
                    ) {
                        createPreset(
                            name: $name
                            expireTime: $expireTime
                            expireFormat: $expireFormat
                            deviceLimit: $deviceLimit
                            sessionLimit: $sessionLimit
                            tags: $tags
                            project: $project
                        ) {
                            id
                            name
                            expireTime
                            expireFormat
                            deviceLimit
                            sessionLimit
                            tags
                            project {id}
                        }
                    }
                ",
                OperationName = "",
                Variables = new
                {
                    name,
                    expireTime,
                    expireFormat,
                    deviceLimit,
                    sessionLimit,
                    tags,
                    project = projectID
                }
            };
        }

        // Protected
        public GraphQLRequest UPDATE_PRESET(string id, string name, int expireTime, string expireFormat, int deviceLimit, int sessionLimit, string[] tags)
        {
            return new GraphQLRequest
            {
                Query = @"
                    mutation updatePreset(
                        $id: ID!
                        $name: String!
                        $expireTime: Number!
                        $expireFormat: String!
                        $deviceLimit: Number!
                        $sessionLimit: Number!
                        $tags: [String]!
                    ) {
                        updatePreset(
                            id: $id
                            name: $name
                            expireTime: $expireTime
                            expireFormat: $expireFormat
                            deviceLimit: $deviceLimit
                            sessionLimit: $sessionLimit
                            tags: $tags
                        )
                    }
                ",
                OperationName = "",
                Variables = new
                {
                    id,
                    name,
                    expireTime,
                    expireFormat,
                    deviceLimit,
                    sessionLimit,
                    tags,
                }
            };
        }

        public GraphQLRequest DELETE_PRESET(string id, string projectID)
        {
            return new GraphQLRequest
            {
                Query = @"
                     mutation deletePreset($id: ID!, $project: ID!) {
                        deletePreset(id: $id, project: $project)
                    }
                ",
                OperationName = "",
                Variables = new
                {
                    id,
                    project = projectID
                }
            };
        }

        // Unprotected
        public GraphQLRequest VALIDATE_LICENCE(string key, string projectID)
        {
            return new GraphQLRequest
            {
                Query = @"
                    mutation validateLicence($key: String!, $project: ID!) {
                        validateLicence(key: $key, project: $project)
                }",
                OperationName = "",
                Variables = new
                {
                    key,
                    project = projectID
                }
            };
        }

        // Unprotected
        public GraphQLRequest START_SESSION(string key, string projectID, string deviceID)
        {
            return new GraphQLRequest
            {
                Query = @"
                    mutation startSession($key: String!, $project: ID!, $device: String!) {
                        startSession(key: $key, project: $project, device: $device)
                }",
                OperationName = "",
                Variables = new
                {
                    key,
                    project = projectID,
                    device = deviceID
                }
            };
        }

        // Unprotected
        public GraphQLRequest VALIDATE_SESSION(string projectID, string deviceID, string sessionID)
        {
            return new GraphQLRequest
            {
                Query = @"
                    mutation validateSession($project: ID!, $device: String!, $session: String!) {
                        validateSession(project: $project, device: $device, session: $session)
                }",
                OperationName = "",
                Variables = new
                {
                    project = projectID,
                    device = deviceID,
                    session = sessionID
                }
            };
        }
    }
}
