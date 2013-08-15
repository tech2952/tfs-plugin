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

taxBuilderProjectNames = %w[
  FormImage.BusinessLogic
  FormImage.FTCommonMCProxy
  FormImage.WCFProxy
  GenPrintWithKeys
  Platform.LocatorData
  PrintRuntime.GenPrint
  PrintRuntime.RenderOutput
  TaxBuilder.ITaxBuilderData
  ]

batchServicesProjectNames = %w[
  BatchEEPrintMergeProcess
  ConverterBusinessLogic
  ConversionRunner
  XmlToPdfConverter
  ]

printClientProjectNames = %w[
  GenPrintModule
  PrintDataModule
  ShellApplication
  TaxFormRendering
  ]

taxBuilderSolution = Solution.new("TaxBuilder", Array.new(), Array.new())
batchServicesSolution = Solution.new("BatchServices", Array.new(), Array.new())
printClientSolution = Solution.new("PrintClient", Array.new(), Array.new())

taxBuilderSolution.files << SolutionFile.new("Rakefile",  Array.new())
batchServicesSolution.files << SolutionFile.new("Rakefile", Array.new())
printClientSolution.files << SolutionFile.new("Rakefile",  Array.new())
  
taxBuilderProjectNames.each() do |name|
  taxBuilderSolution.projects << Project.new(name, Array.new(), true)
end

batchServicesProjectNames.each() do |name|
  batchServicesSolution.projects << Project.new(name, Array.new(), true)
end

printClientProjectNames.each() do |name|
  printClientSolution.projects << Project.new(name, Array.new(), true)
end

runtimePdbSolutions = Array.new()
runtimePdbSolutions << taxBuilderSolution
runtimePdbSolutions << batchServicesSolution
runtimePdbSolutions << printClientSolution

runtimePdb = Package.new("RuntimePDB", runtimePdbSolutions)

runtimePdb.solutions.each() do |solution|
  puts solution.name
  solution.projects.each() do |project|
    puts "   #{project.name}"
  end
  puts "\r\n"
end

runtimePdb.toFile("Packages/runtimePdbPackage.yml")

puts "Done"
