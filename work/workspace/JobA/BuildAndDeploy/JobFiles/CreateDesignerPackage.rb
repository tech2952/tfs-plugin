$LOAD_PATH.unshift File.expand_path("./../../../BuildAndDeploy/BuildTools")
$LOAD_PATH.unshift File.expand_path("./../../../BuildAndDeploy/BuildTools/Jenkins")
$LOAD_PATH.unshift File.expand_path("./../../../BuildAndDeploy/TestTools")
$LOAD_PATH.unshift File.expand_path("\\\\cr-public-a01r\\DevToolsRepository\\BuildAndDeploy\\BuildTools")
$LOAD_PATH.unshift File.expand_path("\\\\cr-public-a01r\\DevToolsRepository\\BuildAndDeploy\\BuildTools\\Jenkins")
$LOAD_PATH.unshift File.expand_path("\\\\cr-public-a01r\\DevToolsRepository\\BuildAndDeploy\\TestTools")
puts $LOAD_PATH

require 'Package'
require 'Solution'
require 'Project'
require 'ChangeSet'
require 'SolutionFile'

taxAppProjectNames = %w[
  TaxApp.CalcEngine
  TaxApp.IntrinsicFunctions
  ]

taxBuilderProjectNames = %w[
  FormImage.ConsoleHost
  FormImage.BusinessLogic
  FormImage.FTCommonMCProxy
  FormImage.WCFProxy
  FormImage.NTService
  FormImage.MetaFileDB
  Platform.Snapshot
  PrintRuntime.GenXmlPrintPages
  PrintRuntime.GenPrint
  GenPrintWithKeys
  TaxBuilder.BuildLib
  TaxBuilder.DesignToolIDE
  TaxBuilder.BuildPrintRuntime
  TaxBuilder.ConvertFadsConstants
  TaxBuilder.ManifestEditor
  TaxBuilder.TestLayout
  TaxBuilder.ViewRuntimeXmlPrintProperties
  ]

formsImportProjectNames = %w[
  ConfigLogXmlLib
  DbObjects
  FormsImport
  FormsImportClient
  ]

appClientProjectNames = %w[
  TaxApp.InterfacesAndConstants
  ]

printClientProjectNames = %w[
  GenPrintModule
  PrintDataModule
  ShellApplication
  TaxFormRendering
  Tests\\PrintDataModule.Tests.NUnit
  Tests\\TaxFormRendering.Tests.NUnit
  ]

deploymentToolsProjectNames = %w[
  Launcher
  ManifestBuilder
  Deployment.Domain
  QueryWorkItems
  StringArgs
  ]

haspOverrideProjectNames = %w[
  HaspOverrideManager
]

taxAppSolution = Solution.new("AppRuntime", Array.new(), Array.new())
taxBuilderSolution = Solution.new("TaxBuilder", Array.new(), Array.new())
formsImportSolution = Solution.new("FormsImport", Array.new(), Array.new())
appClientSolution = Solution.new("AppClient", Array.new(), Array.new())
printClientSolution = Solution.new("PrintClient", Array.new(), Array.new())
deploymentToolsSolution = Solution.new("DeploymentTools", Array.new(), Array.new())
haspOverrideSolution = Solution.new("HaspOverrideManager", Array.new(), Array.new())

taxAppSolution.files << SolutionFile.new("Rakefile",  Array.new())
taxBuilderSolution.files << SolutionFile.new("Rakefile",  Array.new())
formsImportSolution.files << SolutionFile.new("Rakefile",  Array.new())
appClientSolution.files << SolutionFile.new("Rakefile",  Array.new())
printClientSolution.files << SolutionFile.new("Rakefile",  Array.new())
deploymentToolsSolution.files << SolutionFile.new("Rakefile",  Array.new())
haspOverrideSolution.files << SolutionFile.new("Rakefile",  Array.new())
  
taxAppProjectNames.each() do |name|
  taxAppSolution.projects << Project.new(name, Array.new(), true)
end

taxBuilderProjectNames.each() do |name|
  taxBuilderSolution.projects << Project.new(name, Array.new(), true)
end

formsImportProjectNames.each() do |name|
  formsImportSolution.projects << Project.new(name, Array.new(), true)
end

appClientProjectNames.each() do |name|
  appClientSolution.projects << Project.new(name, Array.new(), true)
end

printClientProjectNames.each() do |name|
  printClientSolution.projects << Project.new(name, Array.new(), true)
end

deploymentToolsProjectNames.each() do |name|
  deploymentToolsSolution.projects << Project.new(name, Array.new(), false)
end

haspOverrideProjectNames.each() do |name|
  haspOverrideSolution.projects << Project.new(name, Array.new(), true)
end

designerSolutions = Array.new()
designerSolutions << taxAppSolution
designerSolutions << taxBuilderSolution
designerSolutions << formsImportSolution
designerSolutions << appClientSolution
designerSolutions << printClientSolution
designerSolutions << deploymentToolsSolution
designerSolutions << haspOverrideSolution

designer = Package.new("Designer", designerSolutions)

designer.solutions.each() do |solution|
  puts solution.name
  solution.projects.each() do |project|
    puts "   #{project.name} : Deploy = #{project.shouldDeploy}"
  end
  
  puts "\n"
  
  solution.files.each() do |file|
    puts "   #{file.name}"
  end
  puts "\n"
end

designer.toFile("Packages/designerPackage.yml")

puts "Done"

