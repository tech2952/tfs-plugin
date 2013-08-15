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

taxAppProjectNames = %w[
  TaxApp.CalcEngine
  TaxApp.IntrinsicFunctions
  ]

taxBuilderProjectNames = %w[
  FormImage.BusinessLogic
  GenPrintWithKeys
  Platform.LocatorData
  PrintRuntime.GenPrint
  PrintRuntime.GenXmlPrintPages
  TaxBuilder.AppPrintProperties
  TaxBuilder.FadsLib
  TaxBuilder.GraphicObjects
  TaxBuilder.ITaxBuilderData
  ]

batchServicesProjectNames = %w[
  BatchEEPrintMergeProcess
  ConverterBusinessLogic
  ConversionRunner
  XmlToPdfConverter
  ]

printClientProjectNames = %w[
  TaxFormRendering
  ]

taxAppSolution = Solution.new("AppRuntime", Array.new(), Array.new())
taxBuilderSolution = Solution.new("TaxBuilder", Array.new(), Array.new())
batchServicesSolution = Solution.new("BatchServices", Array.new(), Array.new())
printClientSolution = Solution.new("PrintClient", Array.new(), Array.new())

taxAppSolution.files << SolutionFile.new("Rakefile",  Array.new())
taxBuilderSolution.files << SolutionFile.new("Rakefile",  Array.new())
batchServicesSolution.files << SolutionFile.new("Rakefile", Array.new())
printClientSolution.files << SolutionFile.new("Rakefile",  Array.new())
  
taxAppProjectNames.each() do |name|
  taxAppSolution.projects << Project.new(name, Array.new(), true)
end

taxBuilderProjectNames.each() do |name|
  taxBuilderSolution.projects << Project.new(name, Array.new(), true)
end

batchServicesProjectNames.each() do |name|
  batchServicesSolution.projects << Project.new(name, Array.new(), true)
end

printClientProjectNames.each() do |name|
  printClientSolution.projects << Project.new(name, Array.new(), true)
end

runtimeServerSolutions = Array.new()
runtimeServerSolutions << taxAppSolution
runtimeServerSolutions << taxBuilderSolution
runtimeServerSolutions << batchServicesSolution
runtimeServerSolutions << printClientSolution

runtimeServer = Package.new("RuntimeServer", runtimeServerSolutions)

runtimeServer.solutions.each() do |solution|
  puts solution.name
  solution.projects.each() do |project|
    puts "   #{project.name}"
  end
  puts "\r\n"
end

runtimeServer.toFile("Packages/runtimeServerPackage.yml")

puts "Done"
