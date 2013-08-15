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
  GenPrintWithKeys
  PrintRuntime.GenPrint
  ]

printClientProjectNames = %w[
  ShellApplication
  ]

taxBuilderSolution = Solution.new("TaxBuilder", Array.new(), Array.new())
printClientSolution = Solution.new("PrintClient", Array.new(), Array.new())

taxBuilderSolution.files << SolutionFile.new("Rakefile",  Array.new())
printClientSolution.files << SolutionFile.new("Rakefile",  Array.new())
  
taxBuilderProjectNames.each() do |name|
  taxBuilderSolution.projects << Project.new(name, Array.new(), true)
end

printClientProjectNames.each() do |name|
  printClientSolution.projects << Project.new(name, Array.new(), true)
end

runtimeTypeLibrariesSolutions = Array.new()
runtimeTypeLibrariesSolutions << taxBuilderSolution
runtimeTypeLibrariesSolutions << printClientSolution

runtimeTypeLibraries = Package.new("RuntimeTypeLibraries", runtimeTypeLibrariesSolutions)

runtimeTypeLibraries.solutions.each() do |solution|
  puts solution.name
  solution.projects.each() do |project|
    puts "   #{project.name}"
  end
  puts "\r\n"
end

runtimeTypeLibraries.toFile("Packages/runtimeTypeLibrariesPackage.yml")

puts "Done"
