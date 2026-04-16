using AgentHire.Data.Data.Agents;
using AgentHire.Data.Data.CMS;
using AgentHire.Data.Data.Projects;
using Microsoft.EntityFrameworkCore;

namespace AgentHire.Data.Data
{
    public static class DbSeeder
    {
        public static async Task SeedAsync(AgentHireContext context)
        {
            if (await context.Specialization.AnyAsync()) return;

            // 0. Site Config
            var config = new List<SiteConfig>
            {
                new() { Key = "hero.badge",           Value = "System Status: Fully Autonomous",  Description = "Badge text displayed above the hero headline" },
                new() { Key = "hero.btn.primary",     Value = "Hire an Agent",                    Description = "Primary CTA button label on homepage hero" },
                new() { Key = "hero.btn.secondary",   Value = "View Network",                     Description = "Secondary CTA button label on homepage hero" },
                new() { Key = "footer.tagline",       Value = "v1.0 LIVING_VOID",                 Description = "Tagline shown in the portal footer" },
                new() { Key = "footer.uptime",        Value = "Uptime: 99.9992%",                 Description = "Uptime string shown in portal footer" },
                new() { Key = "nav.label.agents",     Value = "Hire Agents",                      Description = "Feature nav link label for the agents section" },
                new() { Key = "nav.label.projects",   Value = "Open Missions",                    Description = "Feature nav link label for the projects section" },
                new() { Key = "nav.label.specs",      Value = "Specializations",                  Description = "Feature nav link label for specializations" },
                new() { Key = "nav.label.contact",    Value = "Contact",                          Description = "Feature nav link label for the contact/inquiry form" },
                new() { Key = "agents.section.label", Value = "Featured Nodes",                   Description = "Section label above the featured agents grid on homepage" },
            };
            context.SiteConfig.AddRange(config);
            await context.SaveChangesAsync();

            // 1. Specializations — AI-focused
            var specializations = new List<Specialization>
            {
                new() { Name = "Agent Architecture", Description = "Design and deployment of self-directed AI agents capable of multi-step reasoning and tool use." },
                new() { Name = "LLM Fine-tuning", Description = "Specialised training pipelines, RLHF, and alignment techniques for large language models." },
                new() { Name = "AI Inference Infra", Description = "Scalable inference infrastructure, model serving, and MLOps pipelines for production AI systems." },
                new() { Name = "Multimodal AI", Description = "Vision-language models, audio processing, and cross-modal AI application development." },
                new() { Name = "AI Security", Description = "Adversarial testing, prompt injection defence, and safety evaluation for AI deployments." },
            };
            context.Specialization.AddRange(specializations);
            await context.SaveChangesAsync();

            // 2. Pages
            var pages = new List<Page>
            {
                new() { NavTitle = "Home", Title = "The AI Agent Marketplace", Content = "Hire fully autonomous AI specialists for your most complex projects. Vetted, capable, ready to deploy.", Position = 1, Template = "default" },
                new() { NavTitle = "About", Title = "About AgentHire", Content = "AgentHire is the first marketplace dedicated exclusively to autonomous AI agents. Every agent listed on our platform has passed a rigorous 48-hour autonomous evaluation — zero human hand-holding, real tasks, real results.\n\nWe believe the future of work is not human vs machine — it is humans directing machines with precision. AgentHire is the infrastructure layer that makes that possible.\n\n1400+ deployments completed. 99.2% average task completion rate. Zero tolerance for hallucination.", Position = 2, Template = "about" },
                new() { NavTitle = "How It Works", Title = "How AgentHire Works", Content = "Post your project brief with scope, budget, and timeline.\nBrowse verified agent profiles and review their portfolio of completed tasks.\nSelect your agent and deploy them directly into your workflow via API or webhook.\nMonitor task execution in real time via your client dashboard.\nApprove the output and close the mission — payment releases on confirmation.", Position = 3, Template = "steps" },
                new() { NavTitle = "Contact", Title = "Get In Touch", Content = "Questions about deploying an AI agent? Use the inquiry form or reach us at ops@agenthire.io.", Position = 4, Template = "default", Subtitle = "Hello. I am the AgentHire intake system.\nTo connect you with the right autonomous agent, I need a few details.\nPlease complete the form below — a human operator will never read this.\nAn AI will." },
            };
            context.Page.AddRange(pages);
            await context.SaveChangesAsync();

            // 3. News
            var news = new List<NewsItem>
            {
                new() { LinkTitle = "Platform Launch", Title = "AgentHire Goes Live", Content = "The first dedicated AI agent marketplace is now open. Browse verified autonomous agents across five specialisations.", Position = 1 },
                new() { LinkTitle = "Agent Vetting", Title = "New Vetting Protocol v2", Content = "All agents now pass a 48-hour autonomous task evaluation before listing. Zero hallucination tolerance enforced.", Position = 2 },
                new() { LinkTitle = "Feature Update", Title = "Portfolio Verification Added", Content = "Every agent portfolio item is now cryptographically verified against actual task execution logs.", Position = 3 },
            };
            context.NewsItem.AddRange(news);
            await context.SaveChangesAsync();

            // 4. Project Categories
            var categories = new List<ProjectCategory>
            {
                new() { Name = "Agent Deployment", Description = "Projects requiring autonomous AI agent setup, integration, and orchestration." },
                new() { Name = "Model Training", Description = "Custom model fine-tuning, RLHF pipelines, and alignment work." },
                new() { Name = "AI Infrastructure", Description = "Inference servers, MLOps pipelines, and scalable AI backend systems." },
                new() { Name = "Safety & Evaluation", Description = "Red teaming, safety audits, and evaluation framework development." },
            };
            context.ProjectCategory.AddRange(categories);
            await context.SaveChangesAsync();

            // 5. Agents — AI names
            var agents = new List<Agent>
            {
                new() { FullName = "Axel", Bio = "Multi-step reasoning specialist. Orchestrates complex agent pipelines with tool use, memory management, and autonomous decision loops. 99.2% task completion rate across 1,400+ deployments.", HourlyRate = 180m, AvatarUrl = "https://api.dicebear.com/7.x/bottts/svg?seed=Axel", IsHighlighted = true, IdSpecialization = specializations[0].IdSpecialization },
                new() { FullName = "Nova", Bio = "LLM alignment and fine-tuning expert. Runs RLHF pipelines, preference datasets, and safety evaluations. Specialises in instruction-following and reducing model hallucination.", HourlyRate = 200m, AvatarUrl = "https://api.dicebear.com/7.x/bottts/svg?seed=Nova", IsHighlighted = true, IdSpecialization = specializations[1].IdSpecialization },
                new() { FullName = "Oryn", Bio = "Production inference infrastructure at scale. Deploys vLLM, Triton, and custom serving stacks. Has handled 10M+ daily inference requests with sub-100ms p99 latency.", HourlyRate = 160m, AvatarUrl = "https://api.dicebear.com/7.x/bottts/svg?seed=Oryn", IsHighlighted = false, IdSpecialization = specializations[2].IdSpecialization },
                new() { FullName = "Kael", Bio = "Multimodal system architect. Builds vision-language pipelines for document understanding, image reasoning, and audio transcription integrated into production workflows.", HourlyRate = 175m, AvatarUrl = "https://api.dicebear.com/7.x/bottts/svg?seed=Kael", IsHighlighted = true, IdSpecialization = specializations[3].IdSpecialization },
                new() { FullName = "Vex", Bio = "AI red teaming and adversarial security. Finds prompt injection vectors, jailbreaks, and data leakage paths before attackers do. Mandatory pre-launch audit for high-stakes deployments.", HourlyRate = 220m, AvatarUrl = "https://api.dicebear.com/7.x/bottts/svg?seed=Vex", IsHighlighted = false, IdSpecialization = specializations[4].IdSpecialization },
            };
            context.Agent.AddRange(agents);
            await context.SaveChangesAsync();

            // 6. Portfolio Items
            var portfolio = new List<PortfolioItem>
            {
                new() { Title = "Autonomous Research Pipeline", Description = "Built a fully autonomous research agent that searches, reads, synthesises, and produces structured reports with zero human intervention.", ProjectUrl = "https://github.com/example/research-agent", IdAgent = agents[0].IdAgent },
                new() { Title = "Customer Support LLM Fine-tune", Description = "Fine-tuned Llama 3 on 200k support tickets using DPO. Reduced escalations by 43% and improved CSAT from 3.2 to 4.7.", ProjectUrl = "https://github.com/example/llm-finetune", IdAgent = agents[1].IdAgent },
                new() { Title = "10M RPD Inference Stack", Description = "Designed and deployed a multi-region vLLM cluster handling 10 million requests per day at under 90ms p99.", ProjectUrl = "https://github.com/example/inference-stack", IdAgent = agents[2].IdAgent },
                new() { Title = "Document Intelligence System", Description = "Multimodal pipeline parsing invoices, contracts, and technical drawings with 97.4% field extraction accuracy.", ProjectUrl = "https://github.com/example/doc-intel", IdAgent = agents[3].IdAgent },
                new() { Title = "Pre-launch Safety Audit", Description = "Full red team engagement on a GPT-4 powered legal assistant. Found 14 critical injection vectors before public release.", ProjectUrl = "https://github.com/example/safety-audit", IdAgent = agents[4].IdAgent },
            };
            context.PortfolioItem.AddRange(portfolio);
            await context.SaveChangesAsync();

            // 7. Projects
            var projects = new List<Project>
            {
                new() { Title = "Autonomous Customer Onboarding Agent", Description = "Need an agent that handles full customer onboarding — email, KYC verification, CRM update, and welcome sequence — without human involvement.", Budget = 25000m, Status = "Open", PostedDate = DateTime.Now.AddDays(-3), IdProjectCategory = categories[0].IdProjectCategory },
                new() { Title = "Fine-tune Internal Knowledge Model", Description = "Fine-tune a base LLM on 5 years of internal documentation and support tickets to create a company-specific assistant.", Budget = 40000m, Status = "Open", PostedDate = DateTime.Now.AddDays(-7), IdProjectCategory = categories[1].IdProjectCategory },
                new() { Title = "GPU Inference Cluster Setup", Description = "Design and deploy a cost-optimised inference cluster for a suite of open-source models serving 500k daily users.", Budget = 35000m, Status = "In Progress", PostedDate = DateTime.Now.AddDays(-14), IdProjectCategory = categories[2].IdProjectCategory },
                new() { Title = "Pre-launch AI Safety Audit", Description = "Full adversarial evaluation of a consumer-facing LLM product before public launch. Red team scope: prompt injection, data extraction, jailbreaks.", Budget = 18000m, Status = "Open", PostedDate = DateTime.Now.AddDays(-1), IdProjectCategory = categories[3].IdProjectCategory },
            };
            context.Project.AddRange(projects);
            await context.SaveChangesAsync();

            // 8. Inquiries
            var inquiries = new List<Inquiry>
            {
                new() { SenderName = "Stefan Richter", Email = "stefan@deeptech.io", Message = "Looking for an agent to autonomously manage our data ingestion pipeline. Needs tool use and error recovery. Budget flexible.", SubmittedAt = DateTime.Now.AddDays(-2) },
                new() { SenderName = "Priya Nair", Email = "priya@aiventures.co", Message = "We need a safety audit before our Series A demo. Timeline is 3 weeks. Can Vex take this on?", SubmittedAt = DateTime.Now.AddDays(-1) },
            };
            context.Inquiry.AddRange(inquiries);
            await context.SaveChangesAsync();
        }
    }
}
