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
  FormImage.BusinessLogic
  FormImage.FTCommonMCProxy
  FormImage.WCFProxy
  TaxBuilder.AppPrintProperties
  TaxBuilder.DataObjects
  TaxBuilder.FadsLib
  TaxBuilder.GraphicObjects
  TaxBuilder.ITaxBuilderData
  ]

appClientProjectNames = %w[
  TaxApp.InterfacesAndConstants
  ]

printClientProjectNames = %w[
  GenPrintModule  
  PrintDataModule
  ShellApplication
  TaxFormRendering
  ]

taxAppSolution = Solution.new("AppRuntime", Array.new(), Array.new())
taxBuilderSolution = Solution.new("TaxBuilder", Array.new(), Array.new())
appClientSolution = Solution.new("AppClient", Array.new(), Array.new())
printClientSolution = Solution.new("PrintClient", Array.new(), Array.new())
  
taxAppSolution.files << SolutionFile.new("Rakefile",  Array.new())
taxBuilderSolution.files << SolutionFile.new("Rakefile",  Array.new())
appClientSolution.files << SolutionFile.new("Rakefile",  Array.new())
printClientSolution.files << SolutionFile.new("Rakefile",  Array.new())
  
taxAppProjectNames.each() do |name|
  taxAppSolution.projects << Project.new(name, Array.new(), true)
end

taxBuilderProjectNames.each() do |name|
  taxBuilderSolution.projects << Project.new(name, Array.new(), true)
end

appClientProjectNames.each() do |name|
  appClientSolution.projects << Project.new(name, Array.new(), true)
end

printClientProjectNames.each() do |name|
  printClientSolution.projects << Project.new(name, Array.new(), true)
end

runtimeClientSolutions = Array.new()
runtimeClientSolutions << taxAppSolution
runtimeClientSolutions << taxBuilderSolution
runtimeClientSolutions << appClientSolution
runtimeClientSolutions << printClientSolution

runtimeClient = Package.new("RuntimeClient", runtimeClientSolutions)

runtimeClient.solutions.each() do |solution|
  puts solution.name
  solution.projects.each() do |project|
    puts "   #{project.name}"
  end
  puts "\r\n"
end

runtimeClient.toFile("Packages/runtimeClientPackage.yml")

puts "Done"
