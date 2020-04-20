using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SecuresStd.API;
using SecuresStd.Models;
using static SecuresStd.API.Responses;

namespace SecuresStd
{
    public class Manager
    {
        private readonly GraphQL.Client.Http.GraphQLHttpClient client;
        private Mutations mutations = new Mutations();
        private Queries queries = new Queries();

        private string _projectID;
        private string _deviceID;
        private string _sessionID;

        public Manager(string apiKey, string projectID, string host)
        {
            client = new GraphQL.Client.Http.GraphQLHttpClient(host, new GraphQL.Client.Serializer.Newtonsoft.NewtonsoftJsonSerializer());
            Task.Run(() => UseProtectedAPI(apiKey)).Wait();
            _projectID = projectID;
        }

        public Manager(string projectID, string host)
        {
            client = new GraphQL.Client.Http.GraphQLHttpClient(host, new GraphQL.Client.Serializer.Newtonsoft.NewtonsoftJsonSerializer());
            _projectID = projectID;
        }

        private async Task<User> UseProtectedAPI(string apiKey)
        {
            var result = await client.SendMutationAsync<IUseAPIResponse>(mutations.USE_API(apiKey));
            return result.Data.user;
        }

        // Unportected
        public async Task<bool> ValidateLicence(string key)
        {
            var result = await client.SendMutationAsync<IValidateLicenceResponse>(mutations.VALIDATE_LICENCE(key, _projectID));
            return result.Data.validateLicence;
        }

        // Unprotected
        public async Task<Licence> GetLicenceByKey(string key)
        {
            var result = await client.SendQueryAsync<IGetLicenceByKeyResponse>(queries.LICENCEBYKEY(_projectID, key));
            return result.Data.licenceByKey;
        }

        // Unprotected
        public async Task<IStartSessionResponse.StartSession> StartSession(string key)
        {
            var result = await client.SendMutationAsync<IStartSessionResponse>(mutations.START_SESSION(key, _projectID, Guid.NewGuid().ToString("N")));

            _sessionID = result.Data.startSession.sessionID;
            _deviceID = result.Data.startSession.deviceID;

            return result.Data.startSession;
        }

        // Unprotected
        public async Task<bool> ValidateSession()
        {
            var result = await client.SendMutationAsync<IValidateSessionResponse>(mutations.VALIDATE_SESSION(_projectID, _deviceID, _sessionID));
            return result.Data.validateSession;
        }

        // Protected
        public async Task<List<Project>> GetProjects()
        {
            var projects = await client.SendQueryAsync<IProjectsResponse>(queries.PROJECTS());
            return projects.Data.Projects;
        }

        // Proteted
        public async Task<Licence> CreateLicence(string owner, string key, DateTime validFrom, int expireTime, string expireFormat, int deviceLimit, int sessionLimit, string[] tags)
        {
           var resultLicence = await client.SendMutationAsync<ICreateLicenceResponse>(mutations.CREATE_LICENCE(owner, key, validFrom, expireTime, expireFormat, deviceLimit, sessionLimit, tags, _projectID));
           return resultLicence.Data.createLicence;
        }

        // Proteted
        public async Task<bool> DeleteLicence(string key)
        {
            var result = await client.SendMutationAsync<IDeleteLicenceResponse>(mutations.DELETE_LICENCE(key, _projectID));
            return result.Data.deleteLicence;
        }

        // Proteted
        public async Task<bool> UpdateLicence(string id, string owner, string key, DateTime validFrom, DateTime expireAt, int deviceLimit, int sessionLimit, string[] tags)
        {
            var resultLicence = await client.SendMutationAsync<IUpdateLicenceResponse>(mutations.UPDATE_LICENCE(id, owner, key, validFrom, expireAt, deviceLimit, sessionLimit, tags, _projectID));
            return resultLicence.Data.updateLicence;
        }

        // Proteted
        public async Task<Preset> CreatePreset(string name, int expireTime, string expireFormat, int deviceLimit, int sessionLimit, string[] tags)
        {
            var result = await client.SendMutationAsync<ICreatePresetResponse>(mutations.CREATE_PRESET(name, expireTime, expireFormat, deviceLimit, sessionLimit, tags, _projectID));
            return result.Data.createPreset;
        }

        // Proteted
        public async Task<bool> UpdatePreset(string id, string name, int expireTime, string expireFormat, int deviceLimit, int sessionLimit, string[] tags)
        {
            var result = await client.SendMutationAsync<IUpdatePresetResponse>(mutations.UPDATE_PRESET(id, name, expireTime, expireFormat, deviceLimit, sessionLimit, tags));
            return result.Data.updatePreset;
        }

        // Proteted
        public async Task<bool> DeletePreset(string id)
        {
            var result = await client.SendMutationAsync<IDeletePresetResponse>(mutations.DELETE_PRESET(id, _projectID));
            return result.Data.deletePreset;
        }
    }
}
