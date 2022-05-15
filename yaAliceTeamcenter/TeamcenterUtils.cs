﻿using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TCUtils
{
    public static class TeamcenterUtils
    {
        public static async Task<TCSessionInfo> GetInfoAboutTCSession(CookieContainer CookieID)
        {
            string payloadSrc = "{\"header\":{\"state\":{},\"policy\":{}}}";
            var handler = new HttpClientHandler { CookieContainer = CookieID };
            HttpClient httpClient = new HttpClient(handler);
            httpClient.BaseAddress = new Uri(Environment.GetEnvironmentVariable("tcURL") + "/tc/JsonRestServices/Core-2007-01-Session/getTCSessionInfo");

            HttpRequestMessage httpRequest = new HttpRequestMessage(HttpMethod.Post, httpClient.BaseAddress);
            httpRequest.Content = new StringContent(payloadSrc, Encoding.UTF8, "application/json");
            var httpResponse = await PostRequestAsync(httpRequest, httpClient);

            TCSessionInfo tcSessionInfo = JsonConvert.DeserializeObject<TCSessionInfo>(httpResponse);

            return tcSessionInfo;
        }

        public static async Task<ExistPRs> GetExistPRs(CookieContainer CookieID)
        {
            string payloadSrc = "{\"header\":{\"state\":{},\"policy\":{\"useRefCount\":false,\"types\":[{\"name\":\"Apm0RYG\",\"properties\":[{\"name\":\"apm0Rating\"},{\"name\":\"object_string\"}]},{\"name\":\"Qc0ChecklistSpecification\",\"properties\":[{\"name\":\"qc0ChecklistSpecList\"},{\"name\":\"qc0ParentChecklistSpec\"},{\"name\":\"qc0Status\"},{\"name\":\"qc0Number\"},{\"name\":\"qc0AssessmentRequired\"},{\"name\":\"qc0Mandatory\"},{\"name\":\"qc0ChecklistType\"},{\"name\":\"object_desc\"},{\"name\":\"object_string\"}]},{\"name\":\"ConfigurationFamily\",\"properties\":[{\"name\":\"namespace\"},{\"name\":\"name\"},{\"name\":\"object_name\"}]},{\"name\":\"ChangeNoticeRevision\",\"properties\":[{\"name\":\"cm0EffectivityFormula\"},{\"name\":\"object_name\"}]},{\"name\":\"ProblemReportRevision\",\"properties\":[{\"name\":\"item_id\"},{\"name\":\"object_name\"},{\"name\":\"object_desc\"},{\"name\":\"owning_user\"}]},{\"name\":\"Awb0Connection\",\"properties\":[{\"name\":\"ase0ConnectedState\"},{\"name\":\"object_string\"}]},{\"name\":\"Ase0AssocRelationProxy\",\"properties\":[{\"name\":\"ase0EndObject\",\"modifiers\":[{\"name\":\"withProperties\",\"Value\":\"true\"}]},{\"name\":\"object_string\"}]},{\"name\":\"Awb0Element\",\"properties\":[{\"name\":\"awb0Parent\"},{\"name\":\"awb0UnderlyingObject\"},{\"name\":\"awb0Archetype\"},{\"name\":\"awb0CsidPath\",\"modifiers\":[{\"name\":\"excludeUiValues\",\"Value\":\"true\"}]},{\"name\":\"awb0IsSuspect\"},{\"name\":\"object_string\"},{\"name\":\"is_modifiable\"}]},{\"name\":\"Att0MeasurableAttribute\",\"properties\":[{\"name\":\"att1InContext\"},{\"name\":\"object_name\"},{\"name\":\"att0CurrentValue\"},{\"name\":\"att1OpenedContext\"},{\"name\":\"wso_thread\"},{\"name\":\"checked_out\"},{\"name\":\"att0AttributeTable\"},{\"name\":\"object_desc\"},{\"name\":\"object_string\"}]},{\"name\":\"Att0AttributeDefRevision\",\"properties\":[{\"name\":\"att0AttrType\"},{\"name\":\"att0Application\"},{\"name\":\"object_name\"},{\"name\":\"att0Uom\"},{\"name\":\"object_desc\"},{\"name\":\"Att0HasDefaultParamValue\",\"modifiers\":[{\"name\":\"withProperties\",\"Value\":\"true\"}]},{\"name\":\"Att0HasGoalFile\",\"modifiers\":[{\"name\":\"withProperties\",\"Value\":\"true\"}]},{\"name\":\"object_string\"}]},{\"name\":\"Dataset\",\"properties\":[{\"name\":\"object_name\"},{\"name\":\"original_file_name\"},{\"name\":\"ref_list\"},{\"name\":\"fnd0IsCheckOutForSign\"},{\"name\":\"ref_names\"},{\"name\":\"checked_out_user\",\"modifiers\":[{\"name\":\"withProperties\",\"Value\":\"true\"}]},{\"name\":\"checked_out_date\"},{\"name\":\"release_status_list\",\"modifiers\":[{\"name\":\"withProperties\",\"Value\":\"true\"}]},{\"name\":\"fnd0InProcess\"},{\"name\":\"fnd0IsCheckoutable\"},{\"name\":\"object_string\"}]},{\"name\":\"Att1AttributeAlignmentProxy\",\"properties\":[{\"name\":\"att1SourceAttribute\",\"modifiers\":[{\"name\":\"withProperties\",\"Value\":\"true\"}]},{\"name\":\"att1SourceElement\"},{\"name\":\"att1AttrContext\",\"modifiers\":[{\"name\":\"withProperties\",\"Value\":\"true\"}]},{\"name\":\"att1HasParentWriteAccess\"},{\"name\":\"att1Result\"},{\"name\":\"att1ContextObject\"},{\"name\":\"att1AttrInOut\"},{\"name\":\"att1Parent\",\"modifiers\":[{\"name\":\"withProperties\",\"Value\":\"true\"}]},{\"name\":\"crt1IsAddedToVR\"},{\"name\":\"object_string\"}]},{\"name\":\"Att0ParamProject\",\"properties\":[{\"name\":\"Att0HasVariantConfigContext\"},{\"name\":\"Att0HasConfigurationContext\",\"modifiers\":[{\"name\":\"withProperties\",\"Value\":\"true\"}]},{\"name\":\"object_name\"},{\"name\":\"object_string\"}]},{\"name\":\"Att0ParamGroup\",\"properties\":[{\"name\":\"att0ChildParamGroups\"},{\"name\":\"att0ChildParamValues\"},{\"name\":\"att0ParamProject\",\"modifiers\":[{\"name\":\"withProperties\",\"Value\":\"true\"}]},{\"name\":\"att0Parent\"},{\"name\":\"checked_out\"},{\"name\":\"object_name\"},{\"name\":\"object_string\"}]},{\"name\":\"Att0MeasurableAttributeInt\",\"properties\":[{\"name\":\"att0Goal\"},{\"name\":\"att0Min\"},{\"name\":\"att0Max\"},{\"name\":\"object_string\"}]},{\"name\":\"Att0MeasurableAttributeDbl\",\"properties\":[{\"name\":\"att0Goal\"},{\"name\":\"att0Min\"},{\"name\":\"att0Max\"},{\"name\":\"object_string\"}]},{\"name\":\"Att0MeasurableAttributeBool\",\"properties\":[{\"name\":\"att0Goal\"},{\"name\":\"object_string\"}]},{\"name\":\"Att0MeasurableAttributeStr\",\"properties\":[{\"name\":\"att0Goal\"},{\"name\":\"att0Min\"},{\"name\":\"att0Max\"},{\"name\":\"object_string\"}]},{\"name\":\"Att0MeasurableAttributePnt\",\"properties\":[{\"name\":\"att0Goal\"},{\"name\":\"object_string\"}]},{\"name\":\"ConfigurationContext\",\"properties\":[{\"name\":\"revision_rule\",\"modifiers\":[{\"name\":\"withProperties\",\"Value\":\"true\"}]},{\"name\":\"variant_rule\",\"modifiers\":[{\"name\":\"withProperties\",\"Value\":\"true\"}]},{\"name\":\"object_string\"}]},{\"name\":\"Fnd0Branch\",\"properties\":[{\"name\":\"fnd0IsTrunk\"},{\"name\":\"bhv0Labels\",\"modifiers\":[{\"name\":\"withProperties\",\"Value\":\"true\"}]},{\"name\":\"bhv0ReferenceBranch\",\"modifiers\":[{\"name\":\"withProperties\",\"Value\":\"true\"}]},{\"name\":\"bhv0BranchType\"},{\"name\":\"object_string\"}]},{\"name\":\"Bhv1VersionObjectNode\",\"properties\":[{\"name\":\"bhv1OwningBranch\"},{\"name\":\"bhv1OwningObject\"},{\"name\":\"bhv1ParentNode\"},{\"name\":\"bhv1NodeState\"},{\"name\":\"object_string\"}]},{\"name\":\"Bhv1ContentsFolder\",\"properties\":[{\"name\":\"bhv1Name\"},{\"name\":\"bhv1OwningBranch\",\"modifiers\":[{\"name\":\"withProperties\",\"Value\":\"true\"}]},{\"name\":\"object_string\"}]},{\"name\":\"Bhv1BranchObjectNode\",\"properties\":[{\"name\":\"bhv1OwningObject\",\"modifiers\":[{\"name\":\"withProperties\",\"Value\":\"true\"}]},{\"name\":\"object_string\"}]},{\"name\":\"ChangeItemRevision\",\"properties\":[{\"name\":\"cm0DerivableTypes\"},{\"name\":\"CMClosure\"},{\"name\":\"CMDisposition\"},{\"name\":\"CMMaturity\"},{\"name\":\"items_tag\"},{\"name\":\"object_string\"}]},{\"name\":\"Cm1ChangeHistoryElement\",\"properties\":[{\"name\":\"cm1SolutionItemObject\"},{\"name\":\"object_string\"}]},{\"name\":\"UserSession\",\"properties\":[{\"name\":\"cm0GlobalChangeContext\"},{\"name\":\"fnd0displayrule\"},{\"name\":\"fnd0ShowGDPR\"},{\"name\":\"object_string\"}]},{\"name\":\"WorkspaceObject\",\"properties\":[{\"name\":\"cm0AuthoringChangeRevision\"},{\"name\":\"cls0IsEnforcementSatisfied\"},{\"name\":\"owning_project\"},{\"name\":\"has_trace_link\"},{\"name\":\"awp0IsSuspect\"},{\"name\":\"object_name\"},{\"name\":\"fnd0MyWorkflowTasks\"},{\"name\":\"fnd0InProcess\"},{\"name\":\"object_string\"},{\"name\":\"is_modifiable\"}]},{\"name\":\"Cfg0AbsConfiguratorWSO\",\"properties\":[{\"name\":\"release_status_list\",\"modifiers\":[{\"name\":\"withProperties\",\"Value\":\"true\"}]},{\"name\":\"object_string\"}]},{\"name\":\"VariantRule\",\"properties\":[{\"name\":\"release_status_list\",\"modifiers\":[{\"name\":\"withProperties\",\"Value\":\"true\"}]},{\"name\":\"object_string\"}]},{\"name\":\"DocumentRevision\",\"properties\":[{\"name\":\"fnd0SimplifiedDocumentDS\"},{\"name\":\"object_string\"}]},{\"name\":\"BOMLine\",\"properties\":[{\"name\":\"bl_rev_object_name\"}]},{\"name\":\"IAV0CalibDataRevision\",\"properties\":[{\"name\":\"item_revision_id\"},{\"name\":\"item_id\"},{\"name\":\"items_tag\",\"modifiers\":[{\"name\":\"withProperties\",\"Value\":\"true\"}]},{\"name\":\"object_string\"}]},{\"name\":\"Crt0VldnContractRevision\",\"properties\":[{\"name\":\"crt0ChildrenStudies\"},{\"name\":\"Att0HasConfigurationContext\",\"modifiers\":[{\"name\":\"withProperties\",\"Value\":\"true\"}]},{\"name\":\"crt0Configuration\"},{\"name\":\"crt0State\"},{\"name\":\"crt0Domain\"},{\"name\":\"crt0VerificationType\"},{\"name\":\"crt0Result\"},{\"name\":\"crt0ParentVldnContract\"},{\"name\":\"object_string\"}]},{\"name\":\"Col1AppearanceBreakdownSchm\",\"properties\":[{\"name\":\"col1AppearanceArea\"},{\"name\":\"object_string\"}]},{\"name\":\"Awb0ConditionalElement\",\"properties\":[{\"name\":\"awb0OverriddenProperties\"},{\"name\":\"awb0OverrideContexts\"},{\"name\":\"awb0IsVi\"},{\"name\":\"awb0Archetype\"},{\"name\":\"awb0IsPacked\"},{\"name\":\"crt1AddedToAnalysisRequest\"},{\"name\":\"awb0NumberOfChildren\"},{\"name\":\"object_string\"}]},{\"name\":\"ItemRevision\",\"properties\":[{\"name\":\"object_desc\"},{\"name\":\"is_vi\"},{\"name\":\"creation_date\"},{\"name\":\"date_released\"},{\"name\":\"items_tag\",\"modifiers\":[{\"name\":\"withProperties\",\"Value\":\"true\"}]},{\"name\":\"checked_out_user\",\"modifiers\":[{\"name\":\"withProperties\",\"Value\":\"true\"}]},{\"name\":\"checked_out_date\"},{\"name\":\"awp0ConfiguredRevision\"},{\"name\":\"release_status_list\",\"modifiers\":[{\"name\":\"withProperties\",\"Value\":\"true\"}]},{\"name\":\"fnd0InProcess\"},{\"name\":\"object_string\"},{\"name\":\"item_id\"},{\"name\":\"item_revision_id\"},{\"name\":\"object_name\"},{\"name\":\"awb0IsDiscoveryIndexed\"},{\"name\":\"awb0DiscoveryIndexTime\"}]},{\"name\":\"Awb0PartElement\",\"properties\":[{\"name\":\"usg0UsageOccRev\"},{\"name\":\"awb0UnderlyingObjectType\"},{\"name\":\"object_string\"}]},{\"name\":\"Fnd0AbstractOccRevision\",\"properties\":[{\"name\":\"release_status_list\",\"modifiers\":[{\"name\":\"withProperties\",\"Value\":\"true\"}]},{\"name\":\"object_string\"}]},{\"name\":\"Fnd0AppSession\",\"properties\":[{\"name\":\"fnd0Roots\"},{\"name\":\"object_string\"}]},{\"name\":\"Fnd0AlignedDesign\",\"properties\":[{\"name\":\"fnd0Primary\"},{\"name\":\"fnd0UnderlyingObject\"},{\"name\":\"fnd0IsPrimary\"}]},{\"name\":\"Fnd0AlignedPart\",\"properties\":[{\"name\":\"fnd0Primary\"},{\"name\":\"fnd0UnderlyingObject\"},{\"name\":\"fnd0IsPrimary\"}]},{\"name\":\"Item\",\"properties\":[{\"name\":\"is_vi\"},{\"name\":\"checked_out_user\",\"modifiers\":[{\"name\":\"withProperties\",\"Value\":\"true\"}]},{\"name\":\"checked_out_date\"},{\"name\":\"object_string\"}]},{\"name\":\"Awb0ProductContextInfo\",\"properties\":[{\"name\":\"awb0CurrentRevRule\"},{\"name\":\"awb0CurrentVariantRule\"},{\"name\":\"awb0Product\"},{\"name\":\"awb0AutoBookmark\"},{\"name\":\"awb0EffDate\"},{\"name\":\"awb0EffEndItem\"},{\"name\":\"awb0EffUnitNo\"},{\"name\":\"awb0EffectivityGroups\"},{\"name\":\"awb0EndEffDates\"},{\"name\":\"awb0EndEffUnits\"},{\"name\":\"awb0PackSimilarElements\"},{\"name\":\"awb0SupportedFeatures\"},{\"name\":\"fgf0EffectivityDisplay\"},{\"name\":\"fgf0EffContextId\"},{\"name\":\"fgf0EffContextNamespace\"},{\"name\":\"fgf0IntentFormulaList\"},{\"name\":\"fgf0ModelConfigContext\",\"modifiers\":[{\"name\":\"withProperties\",\"Value\":\"true\"}]},{\"name\":\"fgf0PartitionConfigContext\",\"modifiers\":[{\"name\":\"withProperties\",\"Value\":\"true\"}]},{\"name\":\"fgf0PartitionScheme\",\"modifiers\":[{\"name\":\"withProperties\",\"Value\":\"true\"}]},{\"name\":\"fgf0CurrentSourceContext\",\"modifiers\":[{\"name\":\"withProperties\",\"Value\":\"true\"}]},{\"name\":\"fgf0ChangeContext\",\"modifiers\":[{\"name\":\"withProperties\",\"Value\":\"true\"}]},{\"name\":\"fgf0ViewList\"},{\"name\":\"object_string\"}]},{\"name\":\"Mdl0ApplicationModel\",\"properties\":[{\"name\":\"object_name\"}]},{\"name\":\"Fnd0ChangeContext\",\"properties\":[{\"name\":\"fnd0ConfigurationMode\"},{\"name\":\"fnd0ChangeObject\"},{\"name\":\"object_string\"}]},{\"name\":\"Ptn0PartitionScheme\",\"properties\":[{\"name\":\"object_name\"},{\"name\":\"object_string\"}]},{\"name\":\"Ptn0Partition\",\"properties\":[{\"name\":\"ptn0partition_id\"},{\"name\":\"release_status_list\",\"modifiers\":[{\"name\":\"withProperties\",\"Value\":\"true\"}]},{\"name\":\"object_string\"}]},{\"name\":\"Psi0ChecklistQuestion\",\"properties\":[{\"name\":\"psi0ParentChecklist\",\"modifiers\":[{\"name\":\"withProperties\",\"Value\":\"false\"}]},{\"name\":\"release_status_list\",\"modifiers\":[{\"name\":\"withProperties\",\"Value\":\"true\"}]},{\"name\":\"object_string\"}]},{\"name\":\"Prg0AbsEvent\",\"properties\":[{\"name\":\"psi0IsRecalcSeqRequired\"},{\"name\":\"object_name\"},{\"name\":\"object_type\"},{\"name\":\"object_desc\"},{\"name\":\"release_status_list\",\"modifiers\":[{\"name\":\"withProperties\",\"Value\":\"true\"}]},{\"name\":\"prg0State\"},{\"name\":\"prg0plan_id\"},{\"name\":\"prg0Classification\"},{\"name\":\"prg0ActualDate\"},{\"name\":\"prg0ForecastDate\"},{\"name\":\"prg0PlannedDate\"},{\"name\":\"prg0PlanObject\"},{\"name\":\"pgp0EventColor\"},{\"name\":\"prg0EventCode\"},{\"name\":\"object_string\"}]},{\"name\":\"Psi0AbsRIO\",\"properties\":[{\"name\":\"psi0State\"},{\"name\":\"release_status_list\",\"modifiers\":[{\"name\":\"withProperties\",\"Value\":\"true\"}]},{\"name\":\"object_string\"}]},{\"name\":\"Psi0AbsChecklist\",\"properties\":[{\"name\":\"psi0State\"},{\"name\":\"apm0RatedReference\"},{\"name\":\"release_status_list\",\"modifiers\":[{\"name\":\"withProperties\",\"Value\":\"true\"}]},{\"name\":\"object_string\"}]},{\"name\":\"Ipm0PlanRequestForm\",\"properties\":[{\"name\":\"last_release_status\"},{\"name\":\"object_string\"}]},{\"name\":\"Prg0AbsPlan\",\"properties\":[{\"name\":\"object_name\"},{\"name\":\"object_type\"},{\"name\":\"object_desc\"},{\"name\":\"release_status_list\",\"modifiers\":[{\"name\":\"withProperties\",\"Value\":\"true\"}]},{\"name\":\"prg0State\"},{\"name\":\"prg0plan_id\"},{\"name\":\"prg0Classification\"},{\"name\":\"prg0ParentPlan\"},{\"name\":\"prg0AllowsChildren\"},{\"name\":\"prg0AllowedChildTypes\"},{\"name\":\"prg0IsTemplate\"},{\"name\":\"prg0UnitOfTimeMeasure\"},{\"name\":\"object_string\"}]},{\"name\":\"Prg0AbsCriteria\",\"properties\":[{\"name\":\"fnd0State\"},{\"name\":\"release_status_list\",\"modifiers\":[{\"name\":\"withProperties\",\"Value\":\"true\"}]},{\"name\":\"object_string\"}]},{\"name\":\"TC_Project\",\"properties\":[{\"name\":\"fnd0Parent\"},{\"name\":\"fnd0Children\"},{\"name\":\"use_program_security\"},{\"name\":\"object_string\"}]},{\"name\":\"Qam0QualityAction\",\"properties\":[{\"name\":\"qam0Comment\",\"modifiers\":[{\"name\":\"withProperties\",\"Value\":\"false\"}]},{\"name\":\"qam0ConfirmationRequired\",\"modifiers\":[{\"name\":\"withProperties\",\"Value\":\"false\"}]},{\"name\":\"qam0DependentQualityActions\",\"modifiers\":[{\"name\":\"withProperties\",\"Value\":\"false\"}]},{\"name\":\"qam0Targets\",\"modifiers\":[{\"name\":\"withProperties\",\"Value\":\"false\"}]},{\"name\":\"qam0QualityActionStatus\",\"modifiers\":[{\"name\":\"withProperties\",\"Value\":\"false\"}]},{\"name\":\"qam0FeedbackAtCompletion\",\"modifiers\":[{\"name\":\"withProperties\",\"Value\":\"false\"}]},{\"name\":\"qam0AutocompleteByDependent\",\"modifiers\":[{\"name\":\"withProperties\",\"Value\":\"false\"}]},{\"name\":\"qam0QualityActionType\",\"modifiers\":[{\"name\":\"withProperties\",\"Value\":\"false\"}]},{\"name\":\"qam0QualityActionSubtype\",\"modifiers\":[{\"name\":\"withProperties\",\"Value\":\"false\"}]},{\"name\":\"qam0Contexts\"},{\"name\":\"object_string\"}]},{\"name\":\"Qc0CharacteristicsGroup\",\"properties\":[{\"name\":\"object_desc\"},{\"name\":\"object_string\"}]},{\"name\":\"Qc0Failure\",\"properties\":[{\"name\":\"qc0IsLatest\"},{\"name\":\"qc0Status\"},{\"name\":\"qc0ParentFailure\"},{\"name\":\"object_desc\"},{\"name\":\"qc0FailureCode\"},{\"name\":\"qc0BasedOnId\"},{\"name\":\"Qc0HasActions\"},{\"name\":\"Qc0FailureReferences\"},{\"name\":\"Qc0FailureAttachments\"},{\"name\":\"object_name\"},{\"name\":\"release_status_list\",\"modifiers\":[{\"name\":\"withProperties\",\"Value\":\"true\"}]},{\"name\":\"object_string\"}]},{\"name\":\"Qc0MasterCharSpec\",\"properties\":[{\"name\":\"qc0IsLatest\"},{\"name\":\"object_name\"},{\"name\":\"qc0GroupReference\"},{\"name\":\"object_desc\"},{\"name\":\"qc0Criticality\"},{\"name\":\"qc0BasedOnId\"},{\"name\":\"object_string\"}]},{\"name\":\"Qc0VariableCharSpec\",\"properties\":[{\"name\":\"qc0limitation\"},{\"name\":\"qc0UnitOfMeasure\"},{\"name\":\"qc0NominalValue\"},{\"name\":\"qc0ToleranceType\"},{\"name\":\"qc0UpperTolerance\"},{\"name\":\"qc0LowerTolerance\"},{\"name\":\"object_string\"}]},{\"name\":\"FullText\",\"properties\":[{\"name\":\"content_type\"},{\"name\":\"object_string\"}]},{\"name\":\"Arm0RequirementSpecElement\",\"properties\":[{\"name\":\"awb0IsSuspect\"},{\"name\":\"object_string\"}]},{\"name\":\"Arm0RequirementElement\",\"properties\":[{\"name\":\"awb0IsSuspect\"},{\"name\":\"object_string\"}]},{\"name\":\"Arm0ParagraphElement\",\"properties\":[{\"name\":\"awb0IsSuspect\"},{\"name\":\"object_string\"}]},{\"name\":\"RequirementSpec_Revision\",\"properties\":[{\"name\":\"has_trace_link\"},{\"name\":\"object_string\"}]},{\"name\":\"SpecElementRevision\",\"properties\":[{\"name\":\"has_trace_link\"},{\"name\":\"awp0IsSuspect\"},{\"name\":\"object_string\"}]},{\"name\":\"Awp0TraceabilityMatrix\",\"properties\":[{\"name\":\"awp0AttachedMatrix\"},{\"name\":\"object_string\"}]},{\"name\":\"Arm0SummaryTableProxy\",\"properties\":[{\"name\":\"arm0UnderlyingObject\"},{\"name\":\"arm0SourceElement\"},{\"name\":\"awb0UnderlyingObject\"},{\"name\":\"arm0TracelinkCount\"},{\"name\":\"object_string\"}]},{\"name\":\"SchTaskDeliverable\",\"properties\":[{\"name\":\"fnd0DeliverableInstance\"},{\"name\":\"schedule_deliverable\"},{\"name\":\"object_string\"}]},{\"name\":\"SchDeliverable\",\"properties\":[{\"name\":\"deliverable_inst\"},{\"name\":\"object_string\"}]},{\"name\":\"Schedule\",\"properties\":[{\"name\":\"fnd0SummaryTask\",\"modifiers\":[{\"name\":\"withProperties\",\"Value\":\"false\"}]},{\"name\":\"start_date\"},{\"name\":\"finish_date\"},{\"name\":\"schedule_type\"},{\"name\":\"end_date_scheduling\"},{\"name\":\"activeschbaseline_tag\",\"modifiers\":[{\"name\":\"withProperties\",\"Value\":\"false\"}]},{\"name\":\"is_baseline\"},{\"name\":\"is_template\"},{\"name\":\"published\"},{\"name\":\"saw1UnitOfTimeMeasure\"},{\"name\":\"checked_out\"},{\"name\":\"owning_user\"},{\"name\":\"project_list\"},{\"name\":\"object_string\"}]},{\"name\":\"ScheduleTask\",\"properties\":[{\"name\":\"task_type\"},{\"name\":\"schedule_tag\",\"modifiers\":[{\"name\":\"withProperties\",\"Value\":\"true\"}]},{\"name\":\"workflow_process\",\"modifiers\":[{\"name\":\"withProperties\",\"Value\":\"false\"}]},{\"name\":\"privileged_user\",\"modifiers\":[{\"name\":\"withProperties\",\"Value\":\"false\"}]},{\"name\":\"fnd0workflow_owner\",\"modifiers\":[{\"name\":\"withProperties\",\"Value\":\"false\"}]},{\"name\":\"fnd0ParentTask\"},{\"name\":\"duration\"},{\"name\":\"lsd\"},{\"name\":\"saw1DeliverablesCount\"},{\"name\":\"object_string\"}]},{\"name\":\"POM_member\",\"properties\":[{\"name\":\"user\",\"modifiers\":[{\"name\":\"withProperties\",\"Value\":\"true\"}]},{\"name\":\"object_string\"}]},{\"name\":\"ScheduleMember\",\"properties\":[{\"name\":\"resource_tag\"},{\"name\":\"fnd0MemberTypeString\"},{\"name\":\"object_string\"}]},{\"name\":\"TaskDependency\",\"properties\":[{\"name\":\"saw1Name\"},{\"name\":\"object_string\"}]},{\"name\":\"PartLogisticsForm\",\"properties\":[{\"name\":\"isSerialized\"},{\"name\":\"isLot\"},{\"name\":\"preserveQuantity\"},{\"name\":\"isRotable\"},{\"name\":\"sse0isAsset\"},{\"name\":\"isConsumable\"},{\"name\":\"isTraceable\"},{\"name\":\"lifeLimited\"},{\"name\":\"object_string\"}]},{\"name\":\"Smr1PhysicalInstance\",\"properties\":[{\"name\":\"smr1IsLot\"},{\"name\":\"smr1IsSerialized\"},{\"name\":\"object_string\"}]},{\"name\":\"SPR0PartRequest\",\"properties\":[{\"name\":\"approval\"},{\"name\":\"object_string\"}]},{\"name\":\"PhysicalPart\",\"properties\":[{\"name\":\"manufacturingDate\"},{\"name\":\"object_string\"}]},{\"name\":\"Sam1AsMaintainedElement\",\"properties\":[{\"name\":\"awb0Quantity\"},{\"name\":\"smr1PartUsed\"},{\"name\":\"smr1LotTag\"},{\"name\":\"partNumber\"},{\"name\":\"smr1PartNumber\"},{\"name\":\"smr1SerialNumber\"},{\"name\":\"smr1MfgOrgId\"},{\"name\":\"smr1PartUsedInternal\"},{\"name\":\"sam1CurrentLocation\"},{\"name\":\"awb0Archetype\",\"modifiers\":[{\"name\":\"withProperties\",\"Value\":\"true\"}]},{\"name\":\"awb0UnderlyingObject\",\"modifiers\":[{\"name\":\"withProperties\",\"Value\":\"true\"}]},{\"name\":\"object_string\"}]},{\"name\":\"Sab1AsBuiltElement\",\"properties\":[{\"name\":\"smr1PartUsedInternal\"},{\"name\":\"object_string\"}]},{\"name\":\"PhysicalPartRevision\",\"properties\":[{\"name\":\"smr0HasCharacteristics\"},{\"name\":\"PhysicalRealization\",\"modifiers\":[{\"name\":\"withProperties\",\"Value\":\"true\"}]},{\"name\":\"partNumber\"},{\"name\":\"items_tag\",\"modifiers\":[{\"name\":\"withProperties\",\"Value\":\"true\"}]},{\"name\":\"item_id\"},{\"name\":\"sam0InPhysicalLocation\"},{\"name\":\"sam1CurrentLocation\"},{\"name\":\"configContextTag\",\"modifiers\":[{\"name\":\"withProperties\",\"Value\":\"true\"}]},{\"name\":\"sam1CurrentDisposition\",\"modifiers\":[{\"name\":\"withProperties\",\"Value\":\"true\"}]},{\"name\":\"sam1TopLevelPart\",\"modifiers\":[{\"name\":\"withProperties\",\"Value\":\"true\"}]},{\"name\":\"object_string\"}]},{\"name\":\"AllowedDeviation\",\"properties\":[{\"name\":\"deviationTag\"},{\"name\":\"object_string\"}]},{\"name\":\"Job\",\"properties\":[{\"name\":\"process_template\"},{\"name\":\"object_string\"}]},{\"name\":\"Lot\",\"properties\":[{\"name\":\"lotSize\"},{\"name\":\"lotUsage\"},{\"name\":\"lotNumber\"},{\"name\":\"manufacturerOrgId\"},{\"name\":\"owning_site\"},{\"name\":\"object_string\"}]},{\"name\":\"DispositionType\",\"properties\":[{\"name\":\"dispositionValue\"},{\"name\":\"isServiceable\"},{\"name\":\"object_name\"},{\"name\":\"isActive\"},{\"name\":\"object_string\"}]},{\"name\":\"PSOccurrence\",\"properties\":[{\"name\":\"alternate_etc_ref\",\"modifiers\":[{\"name\":\"withProperties\",\"Value\":\"true\"}]},{\"name\":\"child_item\",\"modifiers\":[{\"name\":\"withProperties\",\"Value\":\"true\"}]},{\"name\":\"object_string\"}]},{\"name\":\"PhysicalLocation\",\"properties\":[{\"name\":\"object_name\"},{\"name\":\"object_string\"}]},{\"name\":\"CharacteristicValue\",\"properties\":[{\"name\":\"smr0IsValid\"},{\"name\":\"smr0StringValue\"},{\"name\":\"smr0BooleanValue\"},{\"name\":\"object_string\"}]},{\"name\":\"PSAlternateList\",\"properties\":[{\"name\":\"preferred_item\",\"modifiers\":[{\"name\":\"withProperties\",\"Value\":\"true\"}]},{\"name\":\"alt_items\",\"modifiers\":[{\"name\":\"withProperties\",\"Value\":\"true\"}]},{\"name\":\"object_string\"}]},{\"name\":\"Utilization\",\"properties\":[{\"name\":\"util_char_definition\"},{\"name\":\"swi0minValue\"},{\"name\":\"swi0maxValue\"},{\"name\":\"swi0logEntry\"},{\"name\":\"object_string\"}]},{\"name\":\"ImanSubscription\",\"properties\":[{\"name\":\"subscriber\"},{\"name\":\"is_modifiable\"},{\"name\":\"fnd0EventHandlers\",\"modifiers\":[{\"name\":\"withProperties\",\"Value\":\"true\"}]},{\"name\":\"notification\",\"modifiers\":[{\"name\":\"withProperties\",\"Value\":\"true\"}]},{\"name\":\"event_handler\",\"modifiers\":[{\"name\":\"withProperties\",\"Value\":\"true\"}]},{\"name\":\"fnd0Condition\"},{\"name\":\"target\"},{\"name\":\"attribute_names\"},{\"name\":\"attribute_values\"},{\"name\":\"logic_operators\"},{\"name\":\"math_operators\"},{\"name\":\"handler_parameters\"},{\"name\":\"object_string\"}]},{\"name\":\"Fnd0NotificationTemplate\",\"properties\":[{\"name\":\"subject\"},{\"name\":\"message\"},{\"name\":\"properties\"},{\"name\":\"object_string\"}]},{\"name\":\"ImanActionHandler\",\"properties\":[{\"name\":\"handler_id\"},{\"name\":\"object_string\"}]},{\"name\":\"ImanEventType\",\"properties\":[{\"name\":\"eventtype_id\"},{\"name\":\"fnd0eventtype_name\"},{\"name\":\"object_string\"}]},{\"name\":\"Signoff\",\"properties\":[{\"name\":\"fnd0ParentTask\",\"modifiers\":[{\"name\":\"withProperties\",\"Value\":\"true\"}]},{\"name\":\"object_name\"},{\"name\":\"is_modifiable\"}]},{\"name\":\"EPMTask\",\"properties\":[{\"name\":\"project_task_attachments\",\"modifiers\":[{\"name\":\"withProperties\",\"Value\":\"true\"}]},{\"name\":\"responsible_party\"},{\"name\":\"active_surrogate\"},{\"name\":\"group\"},{\"name\":\"role\"},{\"name\":\"object_string\"}]},{\"name\":\"SSS0JobActivity\",\"properties\":[{\"name\":\"fnd0status\"},{\"name\":\"object_string\"}]},{\"name\":\"SSS0JobTask\",\"properties\":[{\"name\":\"sss0configUpdated\"},{\"name\":\"revision_list\"},{\"name\":\"sss0impactedPhysicalPart\",\"modifiers\":[{\"name\":\"withProperties\",\"Value\":\"true\"}]},{\"name\":\"SSS0RequestsPart\",\"modifiers\":[{\"name\":\"withProperties\",\"Value\":\"true\"}]},{\"name\":\"object_string\"}]},{\"name\":\"MroBOMWindow\",\"properties\":[{\"name\":\"top_line\",\"modifiers\":[{\"name\":\"withProperties\",\"Value\":\"true\"}]},{\"name\":\"object_string\"}]},{\"name\":\"NeutralBOMLine\",\"properties\":[{\"name\":\"phbl_part_number\"},{\"name\":\"npbl_is_item_serialized\"},{\"name\":\"npbl_is_item_lot\"},{\"name\":\"object_string\"}]},{\"name\":\"ImanFile\",\"properties\":[{\"name\":\"original_file_name\"},{\"name\":\"file_ext\"}]},{\"name\":\"Ase1IntfElementProxy\",\"properties\":[{\"name\":\"ase1ExchangeName\"}]},{\"name\":\"ReleaseStatus\",\"properties\":[{\"name\":\"object_name\"},{\"name\":\"date_released\"},{\"name\":\"object_string\"}]},{\"name\":\"POM_imc\",\"properties\":[{\"name\":\"site_id\"},{\"name\":\"name\"}]},{\"name\":\"Form\",\"properties\":[{\"name\":\"checked_out_user\",\"modifiers\":[{\"name\":\"withProperties\",\"Value\":\"true\"}]},{\"name\":\"checked_out_date\"},{\"name\":\"object_string\"}]},{\"name\":\"User\",\"properties\":[{\"name\":\"userid\"},{\"name\":\"object_string\"}]},{\"name\":\"BusinessObject\",\"properties\":[{\"name\":\"awp0CellProperties\"},{\"name\":\"awp0ThumbnailImageTicket\"},{\"name\":\"object_string\"}]},{\"name\":\"Group\",\"properties\":[{\"name\":\"object_full_name\"}]},{\"name\":\"ImanRelation\",\"properties\":[{\"name\":\"relation_type\"},{\"name\":\"is_modifiable\"}]},{\"name\":\"ImanVolume\",\"properties\":[{\"name\":\"volume_name\"}]},{\"name\":\"ListOfValues\",\"properties\":[{\"name\":\"lov_name\"}]},{\"name\":\"MECfgLine\",\"properties\":[{\"name\":\"me_cl_display_string\"}]},{\"name\":\"Person\",\"properties\":[{\"name\":\"user_name\"}]},{\"name\":\"POM_user\",\"properties\":[{\"name\":\"user_name\"}]},{\"name\":\"Role\",\"properties\":[{\"name\":\"role_name\"}]},{\"name\":\"Crt0StudyRevision\",\"properties\":[{\"name\":\"last_mod_date\"},{\"name\":\"object_string\"}]},{\"name\":\"Evm1RecipeResultProxy\",\"properties\":[{\"name\":\"evm1SourceObject\"},{\"name\":\"object_string\"}]},{\"name\":\"Crt0AttributeElement\",\"properties\":[{\"name\":\"crt0Result\"},{\"name\":\"crt0TargetAttr\"},{\"name\":\"object_string\"}]},{\"name\":\"Crt1VRContentProxy\",\"properties\":[{\"name\":\"crt1UnderlyingObject\"},{\"name\":\"crt1HasChildren\"},{\"name\":\"crt1ValidationLink\"},{\"name\":\"object_string\"}]},{\"name\":\"CompanyLocation\",\"properties\":[{\"name\":\"object_name\"},{\"name\":\"city\"},{\"name\":\"country\"},{\"name\":\"vm0DUNSNumber\"},{\"name\":\"state_province\"},{\"name\":\"object_string\"}]},{\"name\":\"ManufacturerPart\",\"properties\":[{\"name\":\"object_name\"},{\"name\":\"vm0vendor_ref\"},{\"name\":\"vm0company_location\"},{\"name\":\"TC_vendor_part_rel\"},{\"name\":\"commercialparts\"},{\"name\":\"license_list\"},{\"name\":\"object_string\"}]},{\"name\":\"Vendor\",\"properties\":[{\"name\":\"VMRepresents\"},{\"name\":\"TC_vendor_part_rel\"},{\"name\":\"Vm0UsesPrtnrContract\"},{\"name\":\"LocationInCompany\"},{\"name\":\"ContactInCompany\"},{\"name\":\"vm0RegistrationStatus\"},{\"name\":\"object_string\"}]},{\"name\":\"VendorRevision\",\"properties\":[{\"name\":\"vendor_role_list\"},{\"name\":\"object_string\"}]},{\"name\":\"CompanyContact\",\"properties\":[{\"name\":\"license_list\"},{\"name\":\"Vm0PartnerUser\"},{\"name\":\"object_string\"}]},{\"name\":\"Vm0PrtnrContractRevision\",\"properties\":[{\"name\":\"license_list\"},{\"name\":\"object_string\"}]},{\"name\":\"EPMTaskTemplate\",\"properties\":[{\"name\":\"template_classification\"},{\"name\":\"stage\"},{\"name\":\"object_name\"},{\"name\":\"object_type\"},{\"name\":\"is_modifiable\"},{\"name\":\"object_string\"}]},{\"name\":\"Awp0XRTObjectSetRow\",\"properties\":[{\"name\":\"is_modifiable\"}]},{\"name\":\"Fnd0TableRow\",\"properties\":[{\"name\":\"is_modifiable\"}]},{\"name\":\"Awp0SearchFolder\",\"properties\":[{\"name\":\"object_string\"},{\"name\":\"object_type\"},{\"name\":\"checked_out\"},{\"name\":\"owning_user\"},{\"name\":\"owning_group\"},{\"name\":\"last_mod_date\"},{\"name\":\"release_status_list\"},{\"name\":\"awp0SearchDefinition\"},{\"name\":\"awp0SearchType\"},{\"name\":\"awp0CanExecuteSearch\"},{\"name\":\"awp0Rule\"},{\"name\":\"awp0IsShared\"}]},{\"name\":\"Awp0FullTextSavedSearch\",\"properties\":[{\"name\":\"object_name\"},{\"name\":\"awp0search_string\"},{\"name\":\"awp0SavedSearchLocale\"},{\"name\":\"creation_date\"},{\"name\":\"awp0string_filters\",\"modifiers\":[{\"name\":\"withProperties\",\"Value\":\"true\"}]},{\"name\":\"last_mod_date\"},{\"name\":\"awp0SearchFilterArray\"},{\"name\":\"owning_user\"},{\"name\":\"awp0is_global_shared\"},{\"name\":\"awp0ChartOn\"}]},{\"name\":\"SavedSearch\",\"properties\":[{\"name\":\"object_name\"},{\"name\":\"savedsearch_attr_names\"},{\"name\":\"savedsearch_attr_values\"},{\"name\":\"shared\"},{\"name\":\"last_mod_date\"},{\"name\":\"savedsearch_query\",\"modifiers\":[{\"name\":\"withProperties\",\"Value\":\"true\"}]},{\"name\":\"owning_user\"},{\"name\":\"saved_search_criteria\"}]},{\"name\":\"SavedQueryCriteria\",\"properties\":[{\"name\":\"fnd0AttributeDisplayValues\"}]},{\"name\":\"Awp0StringSearchFilter\",\"properties\":[{\"name\":\"awp0filter_name\"},{\"name\":\"awp0value\"}]},{\"name\":\"Awp0AdvancedSearchInput\",\"properties\":[{\"name\":\"awp0AdvancedQueryName\"},{\"name\":\"awp0QuickSearchName\"}]}]}},\"body\":{\"searchInput\":{\"maxToLoad\":500,\"maxToReturn\":500,\"providerName\":\"Awp0SavedQuerySearchProvider\",\"searchCriteria\":{\"queryUID\":\"QdkF96Kvppgr6D\",\"searchID\":\"\",\"typeOfSearch\":\"ADVANCED_SEARCH\",\"utcOffset\":\"-420\",\"lastEndIndex\":\"\",\"totalObjectsFoundReportedToClient\":\"\",\"PRID\":\"*\"},\"searchFilterFieldSortType\":\"Priority\",\"startIndex\":0,\"searchFilterMap6\":{},\"searchSortCriteria\":[],\"attributesToInflate\":[],\"internalPropertyName\":\"\",\"columnFilters\":[],\"cursor\":{\"startIndex\":0,\"endIndex\":0,\"startReached\":false,\"endReached\":false},\"focusObjUid\":\"\",\"pagingType\":\"\"},\"inflateProperties\":false,\"columnConfigInput\":{\"clientName\":\"\",\"hostingClientName\":\"\",\"clientScopeURI\":\"\",\"operationType\":\"\",\"columnsToExclude\":[]},\"saveColumnConfigData\":{\"scope\":\"\",\"scopeName\":\"\",\"clientScopeURI\":\"\",\"columnConfigId\":\"\",\"columns\":[]},\"noServiceData\":false}}";
            var handler = new HttpClientHandler { CookieContainer = CookieID };
            HttpClient httpClient = new HttpClient(handler);
            httpClient.BaseAddress = new Uri(Environment.GetEnvironmentVariable("tcURL") + "/tc/JsonRestServices/Internal-AWS2-2019-06-Finder/performSearchViewModel4");

            HttpRequestMessage httpRequest = new HttpRequestMessage(HttpMethod.Post, httpClient.BaseAddress);
            httpRequest.Content = new StringContent(payloadSrc, Encoding.UTF8, "application/json");
            var httpResponse = await PostRequestAsync(httpRequest, httpClient);

            ExistPRs prsresults = JsonConvert.DeserializeObject<ExistPRs>(httpResponse);

            /*Console.WriteLine("Total PRs: " + prsresults.TotalFound);
            Console.WriteLine("----");
             for (int i = 0; i < prsresults.ServiceData.Plain.Count; i++)
            {
                Console.WriteLine("PR ID: " + prsresults.ServiceData.ModelObjects[prsresults.ServiceData.Plain[i]].Props.item_id.dbValues[0].ToString());
                Console.WriteLine("PR Name: " + prsresults.ServiceData.ModelObjects[prsresults.ServiceData.Plain[i]].Props.object_name.dbValues[0].ToString());
                Console.WriteLine("PR Desc: " + prsresults.ServiceData.ModelObjects[prsresults.ServiceData.Plain[i]].Props.object_desc.dbValues[0].ToString());
                Console.WriteLine("PR Owner: " + prsresults.ServiceData.ModelObjects[prsresults.ServiceData.Plain[i]].Props.owning_user.uiValues[0].ToString());
                Console.WriteLine("PR Created: " + prsresults.ServiceData.ModelObjects[prsresults.ServiceData.Plain[i]].Props.creation_date.uiValues[0].ToString());
                Console.WriteLine("----");
            }
            */
            return prsresults;
        }

        public static async Task<(CookieContainer, bool)> LoginToTC()
        {
            var isLoginTCStatus = false;
            string payloadSrc = "{\"header\":{\"state\":{},\"policy\":{}},\"body\":{\"credentials\":{\"user\":\"[userName]\",\"password\":\"[userPassword]\",\"role\":\"\",\"descrimator\":\"\",\"locale\":\"\",\"group\":\"\"}}}";

            var payload = payloadSrc.Replace("[userName]", Environment.GetEnvironmentVariable("userName")).Replace("[userPassword]", Environment.GetEnvironmentVariable("userPassword"));

            var cookieWithAuthKey = new CookieContainer();
            var httpHandler = new HttpClientHandler();
            var httpClient = new HttpClient(httpHandler);
            httpClient.BaseAddress = new Uri(Environment.GetEnvironmentVariable("tcURL") + "/tc/JsonRestServices/Core-2011-06-Session/login");
            //httpClient.DefaultRequestHeaders.Accept.Clear();
            HttpRequestMessage httpRequest = new HttpRequestMessage(HttpMethod.Post, httpClient.BaseAddress);
            httpRequest.Content = new StringContent(payload.ToString(), Encoding.UTF8, "application/json");
            var httpResponse = await PostRequestAsync(httpRequest, httpClient);
            cookieWithAuthKey.Add(httpHandler.CookieContainer.GetCookies(new Uri(Environment.GetEnvironmentVariable("tcURL") + "/tc/JsonRestServices/Core-2011-06-Session/login")));
            TeamcenterResponce myDeserializedTCResponce = JsonConvert.DeserializeObject<TeamcenterResponce>(httpResponse.ToString());
            myDeserializedTCResponce.StatusCode = 200;

            isLoginTCStatus = true;
            return (cookieWithAuthKey, isLoginTCStatus);
        }

        public static async Task<string> PostRequestAsync(HttpRequestMessage postRequest, HttpClient client)
        {
            var response = await client.SendAsync(postRequest);
            var responseString = string.Empty;

            response.EnsureSuccessStatusCode();
            responseString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            return responseString;
        }
    }
}